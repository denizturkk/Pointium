using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserProjectDayApprovalManager : IUserProjectDayApprovalService
    {
        IUserProjectDayApprovalDal _userProjectDayApprovalDal;
        public UserProjectDayApprovalManager(IUserProjectDayApprovalDal userProjectDayApprovalDal)
        {
            _userProjectDayApprovalDal = userProjectDayApprovalDal;
        }
        public IDataResult<UserProjectDayApproval> getUserProjectDayApprovalByName(string name)
        {
            return new SuccessDataResult<UserProjectDayApproval>(_userProjectDayApprovalDal.Get(upda => upda.Name == name));
        }
    }
}
