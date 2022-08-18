using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;
        ICustomerService _customerService;
        IUserService _userService;
        
        public ProjectManager(IProjectDal projectDal,ICustomerService customerService,IUserService userService)
        {
            _projectDal = projectDal;
            _customerService = customerService;
            _userService = userService;
        }
        
        [SecuredOperation("admin,project,project.getallwithdetails")]
        public IDataResult<List<ProjectForGetFunctionsDto>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<ProjectForGetFunctionsDto>>(_projectDal.GetAllWithDetails());
            
        }

        [SecuredOperation("admin,project,project.getallwithdetailsbyleadid")]
        public IDataResult<List<ProjectForGetFunctionsDto>> GetAllWithDetailsByLeadId(int leadById)
        {
            return new SuccessDataResult<List<ProjectForGetFunctionsDto>>(_projectDal.GetAllWithDetailsByLeadById(leadById));

        }


        [SecuredOperation("admin,project,project.update")]
        [ValidationAspect(typeof(ProjectValidator))]
        public IResult Update(Project project)
        {
            IResult result = BusinessRules.Run(checkIfCustomerExist(project.CustomerId),
                                       checkIfAssignedByIdExists(project.AssignedById),
                                       checkIfProjectLeaderExists(project.LeadById),
                                       checkIfStartDateOfProjectIsAppropriate(project),
                                      checkIfProjectNameExist(project.ProjectName)                                                                          
                                       );
            if (result != null)
            {
                return result;

            }
            _projectDal.Update(project);
            return new SuccessResult(Messages.projectUpdated);
        }

        [SecuredOperation("admin,project,project.delete")]
        public IResult Delete(Project project)
        {
            var result =BusinessRules.Run(checkIfProjectIdExists(project.Id));

            if(result!=null)
            {
                return result;
            }

            project.IsDeleted = true;
            _projectDal.Update(project);
            return new SuccessResult();
        }

        [SecuredOperation("admin,project,project.add")]
        [ValidationAspect(typeof(ProjectValidator))]
        public IResult Add(Project project)
        {
            IResult result=BusinessRules.Run(checkIfCustomerExist(project.CustomerId),
                                        checkIfAssignedByIdExists(project.AssignedById),
                                        checkIfProjectLeaderExists(project.LeadById),
                                        checkIfStartDateOfProjectIsAppropriate(project),
                                        checkIfProjectNameExist(project.ProjectName)
                                       );  
            if(result!=null)
            {
                return result;

            }
            project.IsDeleted = false;
            _projectDal.Add(project);
            return new SuccessResult(Messages.ProjectCreated);
        }

        [SecuredOperation("admin,project,project.GetAllUsersByProjectId")]
        public IDataResult<List<UserForProjectDto>> GetAllUsersByProjectId(int projectId)
        {
            IResult result = BusinessRules.Run(checkIfProjectIdExists(projectId));
            if (result != null)
            {
                return new ErrorDataResult<List<UserForProjectDto>>(result.Message);

            }
            return new SuccessDataResult<List<UserForProjectDto>>(_projectDal.GetAllUsersByProjectId(projectId));

        }



        //--------------------------System---------------------------
        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(p => p.IsDeleted == false));
        }

        public IDataResult<List<Project>> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(p => p.CustomerId == CustomerId&&p.IsDeleted==false));
        }

        public  IDataResult<Project> GetById(int Id)
        {
            return new SuccessDataResult<Project>(_projectDal.Get(p=>p.Id==Id&& p.IsDeleted==false));
        }
        public   IDataResult<List<Project>> GetByLeadId(int LeadById)
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(p=>p.LeadById==LeadById&& p.IsDeleted==false));
        }

        //---------------------------Business Rules -----------------------

        private IResult checkIfCustomerExist(int customerId)
        { 
            var result = _customerService.GetById(customerId).Data;
            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CustomerNotExist);
        }  

        
        private IResult checkIfAssignedByIdExists(int assignedById )
        {
            var result = _userService.GetWithDetailsByUserId(assignedById).Data;
            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CheckProjectAssigner);
        }

        private IResult checkIfProjectLeaderExists(int leadById)
        {
            var result = _userService.GetWithDetailsByUserId(leadById).Data;
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CheckProjectLead);
        }

        private IResult checkIfStartDateOfProjectIsAppropriate(Project project)
        {
            if(DateTime.Now<=project.StartedAt)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.StartDateOfProjectError);
        }

        private IResult checkIfProjectNameExist(string projectName)
        {
            var result = _projectDal.GetAll(p => p.ProjectName == projectName).Count;
           
             if (result!=0)
             {
                return  new ErrorResult(Messages.ProjectNameExist);
             }
            return new SuccessResult();
        }
 
        private IResult checkIfProjectIdExists(int projectId)
        {
            var result = _projectDal.Get(p => p.Id == projectId && p.IsDeleted==false);
            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProjectIsNotExists);
        }

       
    }
}
