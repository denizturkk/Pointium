using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserProjectDayService
    {
        IResult Add(UserProjectDay userProjectDay);
        IResult Update(UserProjectDay userProjectDay);
        IDataResult<List<UserProjectDayForGetFunctionsDto>> GetMonthly(int userProjectId,int userId,int year, byte month);
    }
}
