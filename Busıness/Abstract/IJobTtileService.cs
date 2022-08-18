using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IJobTitleService
    {
        IDataResult<List<JobTitle>> GetAll();
        IDataResult<JobTitle> Get(int id);
        IResult Add(JobTitle jobTitle); 
        IResult Delete(JobTitle jobTitle);
        IResult Update (JobTitle jobTitle);

    }
}
