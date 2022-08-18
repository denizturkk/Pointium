using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IScoreTableService 
    {
        IDataResult<List<ScoreTable>> GetAllAbsences();
        IDataResult<List<ScoreTable>> GetAllWorks();
        IDataResult<List<ScoreTable>> GetAll();
        IDataResult<ScoreTable> Get(int id);

    }
}
