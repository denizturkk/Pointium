using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class FieldManager : IFieldService
    {
        IFieldDal _fieldDal;
        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal;
        }
        [SecuredOperation("admin,field,field.add")]
        public IResult Add(Field field)
        {
            var result = BusinessRules.Run(CheckIfFieldNameIsNotExist(field.FieldName));
            if (result!=null)
            {
                return result;
            }
            field.IsDeleted = false;
            _fieldDal.Add(field);
            return new SuccessResult(Messages.FieldAdded);
        }
        
        [SecuredOperation("admin,field,field.delete")]
        public IResult Delete(Field field)
        {
           field.IsDeleted=false;
            _fieldDal.Update(field);
            return new SuccessResult(Messages.FieldDeleted);
        }

        public IDataResult<Field> Get(int id)
        {
            return new SuccessDataResult<Field>(_fieldDal.Get(f => f.Id == id));
        }

        public IDataResult<List<Field>> GetAll()
        {
            return new SuccessDataResult<List<Field>>(_fieldDal.GetAll());
        }

        [SecuredOperation("admin,field,field.update")]
        public IResult Update(Field field)
        {
            var result = BusinessRules.Run(CheckIfFieldNameIsNotExist(field.FieldName));
            if (result != null)
            {
                return result;
            }
            _fieldDal.Update(field);
            return new SuccessResult(Messages.FieldUpdated);
        }
       
        //---------------------business rules---------------
        private IResult CheckIfFieldNameIsNotExist(string fieldName)
        {
            var result=_fieldDal.Get(f => f.FieldName == fieldName);
            if (result==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.fieldNameIsExist);
        }
    }
}
