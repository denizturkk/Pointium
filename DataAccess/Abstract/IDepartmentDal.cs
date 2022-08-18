using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IDepartmentDal : IEntityRepository<Department>
    {
        public List<DepartmentForGetFunctionsDto> GetAllWithDetails();
        public DepartmentForGetFunctionsDto GetWithDetails(int departmentId);
    }
}
