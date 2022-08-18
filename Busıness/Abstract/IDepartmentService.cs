using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<DepartmentForGetFunctionsDto> GetWithDetails(int id);
        IDataResult<List<DepartmentForGetFunctionsDto>> GetAllWithDetails();
        IDataResult<List<Department>> GetAll();
        IDataResult<Department> Get(int id);
        IResult Add(Department department);
        IResult Delete(Department department);
        IResult Update(Department department);
    }
}
