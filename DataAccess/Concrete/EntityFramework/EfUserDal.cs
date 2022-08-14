using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PointiumContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new PointiumContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public  List<UserForGetFunctionsDto> GetAllWithDetails()
        {
            using (var context = new PointiumContext())
            {
                var result = from user in context.Users
                             join userDetail in context.UserDetails
                             on user.Id equals userDetail.UserId
                             
                             where user.Status == true
                            
                             join jobTitle in context.JobTitles
                             on userDetail.JobTitleId equals jobTitle.Id
                            
                             join department in context.Departments
                             on userDetail.DepartmentId equals department.Id
                           
                             select new UserForGetFunctionsDto 
                             {Id=user.Id,
                             FirstName=user.FirstName,
                             LastName=user.LastName,
                             Email=user.Email,
                             JobTitleName=jobTitle.JobTitleName,
                             DepartmentName=department.DepartmentName                         
                             };

                return result.ToList();
            }
        }

        public UserForGetFunctionsDto GetWithDetailsById(int userId)
        {
            using (var context = new PointiumContext())
            {
                var result = from user in context.Users
                             join userDetail in context.UserDetails
                             on user.Id equals userDetail.UserId
                             
                             where user.Status == true
                             
                             join jobTitle in context.JobTitles
                             on userDetail.JobTitleId equals jobTitle.Id
                             
                             where jobTitle.IsDeleted == false
                             
                             join department in context.Departments
                             on userDetail.DepartmentId equals department.Id
                             
                             where user.Id==userId
                             
                             select new UserForGetFunctionsDto
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 JobTitleName = jobTitle.JobTitleName,
                                 DepartmentName = department.DepartmentName
                             };

                return result.FirstOrDefault();
            }
        }

        public UserForGetFunctionsDto GetWithDetailsByEmail(string email)
        {
            using (var context = new PointiumContext())
            {
                var result = from user in context.Users
                             join userDetail in context.UserDetails
                             on user.Id equals userDetail.UserId
                             
                             where user.Status == true
                             
                             join jobTitle in context.JobTitles
                             on userDetail.JobTitleId equals jobTitle.Id
                            
                             where jobTitle.IsDeleted == false
                            
                             join department in context.Departments
                             on userDetail.DepartmentId equals department.Id
                             
                             where user.Email == email
                             select new UserForGetFunctionsDto
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 JobTitleName = jobTitle.JobTitleName,
                                 DepartmentName = department.DepartmentName
                             };

                return result.FirstOrDefault();
            }
        }



    }
}
