using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserProjectDal : IEntityRepository<UserProject>
    {   
        List<ProjectForUserDto> GetAllWithDetailsByUserId(int userId);
    
    }
}