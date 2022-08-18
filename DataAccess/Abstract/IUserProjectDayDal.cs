using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserProjectDayDal:IEntityRepository<UserProjectDay>
    {
         public List<UserProjectDayForGetFunctionsDto> GetMonthly(int userProjectId, int year, byte month);
    }
}
