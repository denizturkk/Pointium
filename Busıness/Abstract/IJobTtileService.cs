using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IJobTtileService
    {
        IDataResult<List<JobTitle>> GetAll();
        IDataResult<JobTitle> GetById(int id);
        IResult Add(); 
        IResult Delete(JobTitle jobTitle);

    }
}
