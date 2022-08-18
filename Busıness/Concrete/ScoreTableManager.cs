using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ScoreTableManager : IScoreTableService
    {
        IScoreTableDal _scoreTableDal;
        public ScoreTableManager(IScoreTableDal scoreTableDal)
        {
            _scoreTableDal=scoreTableDal;
        }

        public IDataResult<ScoreTable> Get(int id)
        {
            return new SuccessDataResult<ScoreTable>(_scoreTableDal.Get(st=>st.Id==id));
        }

        public IDataResult<List<ScoreTable>> GetAll()
        {
            return new SuccessDataResult<List<ScoreTable>>(_scoreTableDal.GetAll());
        }

        public IDataResult<List<ScoreTable>> GetAllAbsences()
        {
            return new SuccessDataResult<List<ScoreTable>>(_scoreTableDal.GetAll(st => st.Type == false));
        }

        public IDataResult<List<ScoreTable>> GetAllWorks()
        {
            return new SuccessDataResult<List<ScoreTable>>(_scoreTableDal.GetAll(st => st.Type == true));
        }
    }
}
