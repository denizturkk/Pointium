using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
        IFieldService _fieldService;
        public DepartmentManager(IDepartmentDal departmentDal,IFieldService fieldService)
        {
            _departmentDal=departmentDal;
            _fieldService=fieldService;
        }

        [SecuredOperation("admin,department.add,department")]
        public IResult Add(Department department)
        {
            var result = BusinessRules.Run(CheckIfFieldExists(department.FieldId),
                CheckIfFieldActive(department.FieldId),
                checkIfDepartmentNameIsNotExist(department.DepartmentName)
                );

            if (result!=null)
            {
                return result;
            }

            department.IsDeleted = false;
            _departmentDal.Add(department);
            return new SuccessResult(Messages.DepartmentAdded);
        }
        [SecuredOperation("admin,department.delete,department")]
        public IResult Delete(Department department)
        {
            department.IsDeleted=true;
            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentDeleted);
        }

        public IDataResult<Department> Get(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(d=>d.Id==id));
        }

        public IDataResult<DepartmentForGetFunctionsDto> GetWithDetails(int id)
        {
            return new SuccessDataResult<DepartmentForGetFunctionsDto>(_departmentDal.GetWithDetails(id));
        }

        public IDataResult<List<DepartmentForGetFunctionsDto>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<DepartmentForGetFunctionsDto>>(_departmentDal.GetAllWithDetails());
        }
        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll());
        }
        [SecuredOperation("admin,department.update,department")]
        public IResult Update(Department department)
        {
            var result = BusinessRules.Run(CheckIfFieldExists(department.FieldId),
                CheckIfFieldActive(department.FieldId),
                checkIfDepartmentNameIsNotExist(department.DepartmentName),
                CheckIfDepartmentExist(department)
                );

            if (result != null)
            {
                return result;
            }

            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentUpdated);
        }

        //------------------Business-----------------------
        private IResult CheckIfDepartmentExist(Department department)
        {
            var result = _departmentDal.Get(d=>d.Id==department.Id);
            
            if (result != null)
            {               
                    return new SuccessResult();
            }
            return new ErrorResult(Messages.DepartmentNotExists); ;
        }

        private  IResult CheckIfFieldExists(int fieldId)
        {
            var result= _fieldService.Get(fieldId);
            if (result.Data!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FieldNotExists); ;
        }
        private IResult CheckIfFieldActive(int fieldId)
        {
            var result = _fieldService.Get(fieldId);
            if (result.Data != null )
            {
                if (result.Data.IsDeleted == false)
                {
                    return new SuccessResult();
                }

                if (result.Data.IsDeleted == true)
                {
                    return new ErrorResult(Messages.FieldIsNotActive);
                }

            }

            return new ErrorResult(Messages.FieldNotExists);
        }
        private IResult checkIfDepartmentNameIsNotExist(string departmentName)
        {
            var result = _departmentDal.Get(d=>d.DepartmentName == departmentName);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.DepartmentNameExists);
        }
    }
}
