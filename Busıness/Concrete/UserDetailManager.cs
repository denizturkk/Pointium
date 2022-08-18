using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
        IUserService _userService;
        IDepartmentService _departmentService;
        IJobTitleService _jobTitleService;
        public UserDetailManager(IUserDetailDal userDetailDal,IUserService userService,IDepartmentService departmentService,IJobTitleService jobTitleService)
        {
            _userDetailDal = userDetailDal;
            _userService = userService;
            _departmentService = departmentService;
            _jobTitleService = jobTitleService;
        }

        
        public IResult Add(UserDetail userDetail)
        {
            var result = BusinessRules.Run(
                CheckIfUserExists(userDetail.UserId),
                CheckIfUserDetailEmpty(userDetail.UserId),
                CheckIfDepartmentExist(userDetail.DepartmentId),
                CheckIfDepartmentActive(userDetail.DepartmentId),
                CheckIfJobTitleExist(userDetail.JobTitleId),
                CheckIfJobTitleActive(userDetail.JobTitleId),
                CheckIfNationalIdentityIsAppropriate(userDetail.NationalIdentity)
                );
            
            if(result!=null)
            {
                return result;
            }

            _userDetailDal.Add(userDetail);
            return  new SuccessResult(Messages.UserDetailAdded);
        }

        public IResult GetByUserId(int userId)
        {
            return new SuccessDataResult<UserDetail>(_userDetailDal.Get(p=>p.UserId==userId));
        }

        public IResult Update(UserDetail userDetail)
        {
            var result = BusinessRules.Run(
              CheckIfUserExists(userDetail.UserId),
              CheckIfUserDetailEmpty(userDetail.UserId),
              CheckIfDepartmentExist(userDetail.DepartmentId),
              CheckIfDepartmentActive(userDetail.DepartmentId),
              CheckIfJobTitleExist(userDetail.JobTitleId),
              CheckIfJobTitleActive(userDetail.JobTitleId),
              CheckIfNationalIdentityIsAppropriate(userDetail.NationalIdentity)
              );

            if (result != null)
            {
                return result;
            }
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

       

        private IResult CheckIfUserExists(int userId)
        {
            var result = _userService.GetWithDetailsByUserId(userId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserDetailEmpty(int userId)
        {
            var result = _userDetailDal.Get(ud => ud.UserId == userId);
            if(result==null)
            {
                return new SuccessResult();
                
            }
            return new ErrorResult(Messages.UserDetailExist);
        }

        private IResult CheckIfDepartmentExist(int departmentId)
        {
            var result = _departmentService.Get(departmentId);
            if (result.Data!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.DepartmentNotExists);
        }

        private IResult CheckIfDepartmentActive(int departmentId)
        {
            var result = _departmentService.Get(departmentId);
            if (result.Data != null)
            {
                if (result.Data.IsDeleted==true)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.DepartmentIsNotActive);
               
            }
            return new ErrorResult(Messages.DepartmentNotExists);
        }

        private IResult CheckIfJobTitleActive(int jobTitleId)
        {
            var result = _jobTitleService.Get(jobTitleId);
            if (result.Data != null)
            {
                if (result.Data.IsDeleted == true)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.JobTitleIsNotActive);

            }
            return new ErrorResult(Messages.JobTitleNotExists);
        }

        private IResult CheckIfJobTitleExist(int jobTitleId)
        {
            var result = _jobTitleService.Get(jobTitleId);
            if (result.Data != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.JobTitleNotExists);
        }

        private IResult CheckIfNationalIdentityIsAppropriate(string nationalIdentity)
        {
            var result = _userDetailDal.Get(ud=>ud.NationalIdentity==nationalIdentity);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NationalIdentityCantDuplicate);
        }



    }
}
