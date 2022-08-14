using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        IDataResult<UserForGetFunctionsDto> GetWithDetailsByUserId(int id);
        IDataResult<UserForGetFunctionsDto> GetWithDetailsByEmail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserForGetFunctionsDto>> GetAllWithDetails();

    }
}
