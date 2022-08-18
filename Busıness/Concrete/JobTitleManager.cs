using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class JobTitleManager : IJobTitleService
    {
        IJobTitleDal _jobTitleDal;
        public JobTitleManager(IJobTitleDal jobTitleDal)
        {
            _jobTitleDal = jobTitleDal;
        }

        [SecuredOperation("admin,jobtitle,jobtitle.add")]
        public IResult Add(JobTitle jobTitle)
        {
            var result = BusinessRules.Run(checkIfJobTitleNameIsNotExist(jobTitle.JobTitleName));
            if (result!=null)
            {
                return result;
            }

            jobTitle.IsDeleted = false;
            _jobTitleDal.Add(jobTitle);
            return new SuccessResult(Messages.JobTitleAdded);
        }
        [SecuredOperation("admin,jobtitle,jobtitle.delete")]
        public IResult Delete(JobTitle jobTitle)
        {
            jobTitle.IsDeleted = true;
            _jobTitleDal.Update(jobTitle);
            return new SuccessResult(Messages.jobTitleDeleted);
        }
        public IDataResult<List<JobTitle>> GetAll()
        {
            return new SuccessDataResult<List<JobTitle>>(_jobTitleDal.GetAll(jt => jt.IsDeleted == false));
        }
        public IDataResult<JobTitle> Get(int id)
        {
            return new SuccessDataResult<JobTitle>(_jobTitleDal.Get(jt => jt.Id == id));
        }
        [SecuredOperation("admin,jobtitle,jobtitle.update")]
        public IResult Update(JobTitle jobTitle)
        {
            var result = BusinessRules.Run(checkIfJobTitleNameIsNotExist(jobTitle.JobTitleName));
            if (result != null)
            {
                return result;
            }
            _jobTitleDal.Update(jobTitle);
            return new SuccessResult(Messages.jobTitleUpdated);
        }

        private IResult checkIfJobTitleNameIsNotExist(string jobTitleName)
        {
            var result = _jobTitleDal.Get(jt=>jt.JobTitleName==jobTitleName);
            if (result==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.jobTitleNameExists);
        }
    }
}
