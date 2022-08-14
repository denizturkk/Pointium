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
    public class UserProjectDayManager:IUserProjectDayService
    {
        IUserProjectDayDal _userProjectDayDal;
        IUserProjectService _userProjectService;
        public UserProjectDayManager(IUserProjectDayDal userProjectDayDal,IUserProjectService userProjectService)
        {
            _userProjectDayDal = userProjectDayDal;
            _userProjectService = userProjectService;
        }

        public IResult Add(UserProjectDay userProjectDay)
        {
            _userProjectDayDal.Add(userProjectDay);
            return new SuccessResult(Messages.ScoreAdded);
        }

        public IResult GetAllByUserProjectId(int userProjectId ,int userId)
        {
            return new SuccessDataResult<List<UserProjectDay>>();
        }





    }
}
