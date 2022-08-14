using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserDetailService 
    {

        IResult Add(UserDetail userDetail);
        IResult Update(UserDetail userDetail);
       // IResult Delete(UserDetail userDetail);
        IResult GetByUserId(int userId);
        IResult Get(int id);
        IResult GetAll();


    }
}
