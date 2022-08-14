using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProjectDal : IEntityRepository<Project>
    {
        List<ProjectForGetFunctionsDto> GetAllWithDetails();
        List<ProjectForGetFunctionsDto> GetAllWithDetailsByLeadById(int leadById);
        List<UserForProjectDto> GetAllUsersByProjectId(int projectId);
    }
}
