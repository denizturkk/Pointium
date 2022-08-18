using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserProjectDayManager : IUserProjectDayService
    {
        IUserProjectDayDal _userProjectDayDal;
        IUserProjectService _userProjectService;
        IScoreTableService _scoreTableService;


        public UserProjectDayManager(IUserProjectDayDal userProjectDayDal, IUserProjectService userProjectService, IScoreTableService scoreTableService)
        {
            _userProjectDayDal = userProjectDayDal;
            _userProjectService = userProjectService;
            _scoreTableService = scoreTableService;
        }
        
        
        public IResult Add(UserProjectDay userProjectDay)
        {
            var result = BusinessRules.Run(
                CheckIfUserProjectExist(userProjectDay),
                CheckIfDayInputIsAvaliable(userProjectDay),
                CheckIfScoreTableStatusIsActive(userProjectDay.ScoreTableId)
                );
                                           
            if (result != null)
            {
                return result;
            }

            userProjectDay.CreatedAt = DateTime.Now;
            userProjectDay.UserProjectDayApprovalId = 4; /*_userProjectDayApprovalService.getUserProjectDayApprovalByName("Pending").Data.Id; */
            _userProjectDayDal.Add(userProjectDay);
            return new SuccessResult(Messages.ScoreAdded);
        }

        public IDataResult<List<UserProjectDayForGetFunctionsDto>> GetMonthly(int userProjectId,int userId,int year, byte month)
        {
            var result = BusinessRules.Run(CheckIfUserProjectMatchWithUser(userProjectId,userId));

            if (result != null)
            {
                return new ErrorDataResult<List<UserProjectDayForGetFunctionsDto>>(result.Message);
            }


            return new SuccessDataResult<List<UserProjectDayForGetFunctionsDto>>(_userProjectDayDal.GetMonthly(userProjectId,year,month));
        }

        public IResult Update(UserProjectDay userProjectDay)
        {
            var result = BusinessRules.Run(
                        CheckIfUserProjectExist(userProjectDay),
                        CheckIfDayInputIsAvaliable(userProjectDay),
                        CheckIfScoreTableStatusIsActive(userProjectDay.ScoreTableId)
                );

            if (result != null)
            {
                return result;
            }

            _userProjectDayDal.Update(userProjectDay);
            return new SuccessResult(Messages.ScoreUpdated);
        }



       //---------------------BUSINESSS-------------------------------------------
        private IResult CheckIfUserProjectExist(UserProjectDay userProjectDay)
        {
            var result = _userProjectService.Get(userProjectDay.UserProjectId);

            if (result != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.UserProjectNotExist);
        }

        private IResult CheckIfDayInputIsAvaliable(UserProjectDay userProjectDay)
        {
            var result = _userProjectDayDal.Get(upd=>upd.DayId==userProjectDay.DayId && upd.UserProjectId==userProjectDay.UserProjectId);

            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.AllreadyHaveScoreInput);

        }

        private IResult CheckIfUserProjectMatchWithUser(int userProjectId,int userId)
        {
            var result = _userProjectService.Get(userProjectId);

            if (result!=null)
            {
                if (result.Data.UserId == userId)

                    return new SuccessResult();

                else
                    return new ErrorResult(Messages.UserDoesntMatchWithProject);

            }

            return new ErrorResult(Messages.UserProjectNotExist);
        }

        private IResult CheckIfScoreTableStatusIsActive(int scoreTableId)
        {
            var result = _scoreTableService.Get(scoreTableId);
          
            if(result.Data.Status==true)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.ScoreTableInputIsNotActive);

        }
    }
}
