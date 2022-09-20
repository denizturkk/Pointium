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
    public class EfProjectDal : EfEntityRepositoryBase<Project, PointiumContext>, IProjectDal
    {


        public ProjectForGetFunctionsDto GetWithDetailsById(int id)
        {
            using (var context = new PointiumContext())
            {
                var result = from customer in context.Customers
                             join project in context.Projects
                             on customer.Id equals project.CustomerId
                             

                             join user in context.Users
                             on project.LeadById equals user.Id

                             join assignerUser in context.Users
                             on project.AssignedById equals assignerUser.Id

                             where project.IsDeleted == false
                             where project.Id == id

                             select new ProjectForGetFunctionsDto
                             {
                                 Id = project.Id,
                                 CustomerId = project.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 LeadById = project.LeadById,
                                 LeadByFirstName = user.FirstName,
                                 LeadByLastName = user.LastName,
                                 leadByEMail = user.Email,
                                 AssignedById = project.AssignedById,
                                 AssignerFirstName = assignerUser.FirstName,
                                 AssignerLastName = assignerUser.LastName,
                                 AssignerMail = assignerUser.Email,
                                 ProjectName = project.ProjectName,
                                 Status = project.Status,
                                 Explanation = project.Explanation,
                                 StartedAt = project.StartedAt
                             };

                return result.SingleOrDefault();
            }
        }


        public List<ProjectForGetFunctionsDto> GetAllWithDetails()
        {
            using (var context = new PointiumContext())
            {
                var result = from customer in context.Customers
                             join project in context.Projects
                             on customer.Id equals project.CustomerId
                             
                             join user in context.Users
                             on project.LeadById equals user.Id
                            
                             join assignerUser in context.Users
                             on project.AssignedById equals assignerUser.Id
                             
                             where project.IsDeleted == false
                             
                             select new ProjectForGetFunctionsDto
                             {
                                 Id = project.Id,
                                 CustomerId = project.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 LeadById = project.LeadById,
                                 LeadByFirstName = user.FirstName,
                                 LeadByLastName = user.LastName,
                                 leadByEMail = user.Email,
                                 AssignedById = project.AssignedById,
                                 AssignerFirstName=assignerUser.FirstName,
                                 AssignerLastName=assignerUser.LastName,
                                 AssignerMail=assignerUser.Email,
                                 ProjectName = project.ProjectName,
                                 Status = project.Status,
                                 Explanation = project.Explanation,
                                 StartedAt = project.StartedAt
                             };

                return result.ToList();
            }
        }

       public List<ProjectForGetFunctionsDto> GetAllWithDetailsByLeadById(int leadById)
        {
                using (var context = new PointiumContext())
                {
                var result = from customer in context.Customers
                             join project in context.Projects
                             on customer.Id equals project.CustomerId

                             join user in context.Users
                             on project.LeadById equals user.Id

                             join assignerUser in context.Users
                             on project.AssignedById equals assignerUser.Id

                             where project.IsDeleted == false
                             where project.LeadById == leadById
                                
                                 select new ProjectForGetFunctionsDto
                                 {
                                     Id = project.Id,
                                     CustomerId = project.CustomerId,
                                     CompanyName = customer.CompanyName,
                                     LeadById = project.LeadById,
                                     LeadByFirstName = user.FirstName,
                                     LeadByLastName = user.LastName,
                                     leadByEMail = user.Email,
                                     AssignedById = project.AssignedById,
                                     AssignerFirstName = assignerUser.FirstName,
                                     AssignerLastName = assignerUser.LastName,
                                     AssignerMail = assignerUser.Email,
                                     ProjectName = project.ProjectName,
                                     Status = project.Status,
                                     Explanation = project.Explanation,
                                     StartedAt = project.StartedAt
                                 };

                    return result.ToList();
                }
        }

        public List<UserForProjectDto> GetAllUsersByProjectId(int projectId)
        {
            using (var context = new PointiumContext())
            {
                var result = from project in context.Projects
                             join userProject in context.UserProjects
                             on project.Id equals userProject.ProjectId
                             where project.Id == projectId
                             where userProject.IsDeleted==false

                             join user in context.Users
                             on userProject.UserId equals user.Id
                          
                             join userDetail in context.UserDetails
                             on user.Id equals userDetail.UserId

                             join jobTitle in context.JobTitles
                             on userDetail.JobTitleId equals jobTitle.Id

                             join department in context.Departments
                             on userDetail.DepartmentId equals department.Id

                             join assignerUser in context.Users
                             on userProject.AssignedById equals assignerUser.Id

                             select new UserForProjectDto
                             {
                                Id=user.Id,
                                FirstName=user.FirstName,
                                LastName=user.LastName,
                                Email=user.Email,
                                JobTitleName = jobTitle.JobTitleName,
                                DepartmentName =department.DepartmentName,
                                StartedAt=userProject.StartedAt,
                                AssignedByFirstName=assignerUser.FirstName,
                                AssignedByLastName=assignerUser.LastName,
                                AssignedByEmail=assignerUser.Email,
                                
                             };
                return result.ToList();
            }
        }
    }
}
