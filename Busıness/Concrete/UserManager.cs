using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<UserForGetFunctionsDto> GetWithDetailsByEmail(string email)
        {
            return new SuccessDataResult<UserForGetFunctionsDto>(_userDal.GetWithDetailsByEmail(email));
        }

        public IDataResult<UserForGetFunctionsDto> GetWithDetailsByUserId(int id)
        {
            return new SuccessDataResult<UserForGetFunctionsDto>(_userDal.GetWithDetailsById(id));
        }

        public IDataResult<List<UserForGetFunctionsDto>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<UserForGetFunctionsDto>>(_userDal.GetAllWithDetails());
        }

       //-----------AUTH-------------
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        
        //-----------SYSTEM-------------

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

    }
}
