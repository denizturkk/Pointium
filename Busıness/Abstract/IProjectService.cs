using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectService
    {

        IDataResult<List<ProjectForGetFunctionsDto>> GetAllWithDetails();
        IDataResult<List<ProjectForGetFunctionsDto>> GetAllWithDetailsByLeadId(int leadById);
        IDataResult<List<UserForProjectDto>> GetAllUsersByProjectId(int projectId);
        IDataResult<ProjectForGetFunctionsDto> GetWithDetailsById(int id);
        IResult Add(Project project);
        IResult Update(Project project);
        IResult Delete(Project project);


        IDataResult<List<Project>> GetAll();
        IDataResult<Project> GetById(int id);
        IDataResult<List<Project>> GetByLeadId(int id);
        IDataResult<List<Project>> GetByCustomerId(int id);
        
       

    }
}
