using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class UserProjectManager : IUserProjectService
    {
         IUserProjectDal _userProjectDal;
        public UserProjectManager(IUserProjectDal userProjectDal)
        {
            _userProjectDal = userProjectDal;
        }

        [SecuredOperation("admin,userproject,userproject.add")]
        public IResult Add(UserProject userProject)
        {
            var result = BusinessRules.Run(CheckIfUserDoesNotExistInProject(userProject));
            if (result != null)
            {
                return result;
            }
            userProject.IsDeleted = false;
            _userProjectDal.Add(userProject);
            return new SuccessResult(Messages.UserAddedToProject);
        }

        [SecuredOperation("admin,userproject,userproject.delete")]
        public IResult Delete(UserProject userProject)
        {
            userProject.IsDeleted = true;
            _userProjectDal.Update(userProject);
            return new SuccessResult(Messages.UserDeletedFromProject);
        }

  
        //kullanici icin proje listesi
        public IResult GetAllWithDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<ProjectForUserDto>>(_userProjectDal.GetAllWithDetailsByUserId(userId));
        }

      

        //----------------------------SYSTEM-----------------------------

        //STATU FALSE'A CEKILECEGINDE VEYA SILINECEGINDE KULLANILIR.
        public IResult Update(UserProject userProject)
        {
            _userProjectDal.Update(userProject);
            return new SuccessResult(Messages.UserProjectUpdated);
        }

        public IDataResult<UserProject> Get(int id)
        {
            return new SuccessDataResult<UserProject>(_userProjectDal.Get(p=>p.Id==id && p.IsDeleted==false));
        }


        public IResult GetAll()
        {
            return new SuccessDataResult<List<UserProject>>(_userProjectDal.GetAll(p=>p.IsDeleted==false));
        }

        public IDataResult<UserProject> GetUserProjectByUserAndProject(int userId, int projectId)
        {
            return new SuccessDataResult<UserProject>(_userProjectDal.Get(p => p.UserId == userId && p.ProjectId == projectId && p.IsDeleted == false));
        }

        //-------------------------BUSINESSS RULES---------------------------------------
        private IResult CheckIfUserDoesNotExistInProject(UserProject userProject)
        {
            var result = _userProjectDal.Get(up => up.UserId == userProject.UserId && up.ProjectId == userProject.ProjectId);

            if (result==null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.UserAllreadyExistInProject);
        }


    }
}
