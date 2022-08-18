using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFieldService
    {
        IResult Add(Field field);
        IResult Update(Field field);
        IResult Delete(Field field);
        IDataResult<Field> Get(int id);
        IDataResult<List<Field>> GetAll();

    }
}
