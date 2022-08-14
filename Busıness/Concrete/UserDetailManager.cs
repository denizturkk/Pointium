using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserDetailManager : IUserDetailService
    {
         IUserDetailDal _userDetailDal;
        public UserDetailManager(IUserDetailDal userDetailDal)
        {
                _userDetailDal = userDetailDal;
        }

        
        public IResult Add(UserDetail userDetail)
        {
            _userDetailDal.Add(userDetail);
            return  new SuccessResult(Messages.UserDetailAdded);
        }

        /*
        public IResult Delete(UserDetail userDetail)
        {
            _userDetailDal.Delete(userDetail);
            return new SuccessResult(Messages.UserDetailDeleted);
        }
        */
        public IResult GetByUserId(int userId)
        {
            return new SuccessDataResult<UserDetail>(_userDetailDal.Get(p=>p.UserId==userId));
        }

        public IResult Update(UserDetail userDetail)
        {
            _userDetailDal.Update(userDetail);
            return new SuccessResult(Messages.UserDetailUpdated);
        }

        public IResult GetAll()
        {
            return new SuccessDataResult<List<UserDetail>>(_userDetailDal.GetAll());
        }

        public IResult Get(int id)
        {
            return new SuccessDataResult<UserDetail>(_userDetailDal.Get(p => p.Id == id));
        }
    }
}
