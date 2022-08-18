using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal: EfEntityRepositoryBase<Department, PointiumContext>, IDepartmentDal
    {
        public List<DepartmentForGetFunctionsDto> GetAllWithDetails()
        {
            using (var context = new PointiumContext())
            {
                var result = from field in context.Fields
                             join department in context.Departments
                             on field.Id equals department.Id

                             select new DepartmentForGetFunctionsDto
                             {
                                 Id = department.Id,
                                 FieldId = field.Id,
                                 FieldName = field.FieldName,
                                 DepartmentName = department.DepartmentName,
                                 IsDeleted = department.IsDeleted
                                
                             };

                return result.ToList();
            }
        }

        public DepartmentForGetFunctionsDto GetWithDetails(int departmentId)
        {
            using (var context = new PointiumContext())
            {
                var result = from field in context.Fields
                             join department in context.Departments
                             on field.Id equals department.Id
                             where department.Id == departmentId

                             select new DepartmentForGetFunctionsDto
                             {
                                 Id = department.Id,
                                 FieldId = field.Id,
                                 FieldName = field.FieldName,
                                 DepartmentName = department.DepartmentName,
                                 IsDeleted = department.IsDeleted

                             };

                return result.SingleOrDefault();
            }
        }

    }
}
