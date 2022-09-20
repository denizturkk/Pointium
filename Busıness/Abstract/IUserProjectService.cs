using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
       public interface IUserProjectService
    {
        IResult Add(UserProject userProject);
        IResult Update(UserProject userProject);
        IResult Delete(UserProject userProject);
        IResult GetAll();
        IDataResult<UserProject> Get(int id);
        IResult GetAllWithDetailsByUserId(int userId);
        IDataResult<UserProject> GetUserProjectByUserAndProject(int userId,int projectId);

    }
}
