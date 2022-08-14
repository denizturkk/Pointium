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
    public class EfUserProjectDal: EfEntityRepositoryBase<UserProject, PointiumContext>, IUserProjectDal
    {
        public List<ProjectForUserDto> GetAllWithDetailsByUserId(int userId)
        {
            using (var context = new PointiumContext())
            {

                var result = from userProject in context.UserProjects
                             join project in context.Projects
                             on userProject.ProjectId equals project.Id
                             where userProject.UserId==userId


                             join user in context.Users
                             on userProject.UserId equals user.Id
                             where userProject.UserId == userId

                             join assignedByUser in context.Users
                             on userProject.AssignedById equals assignedByUser.Id

                             where project.IsDeleted == false
                             where userProject.IsDeleted == false
                             where userProject.UserId==userId
                             select new ProjectForUserDto
                             {
                                 Id = userProject.Id,
                                 ProjectId = project.Id,
                                 ProjectName = project.ProjectName,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 AssignedById = assignedByUser.Id,
                                 AssignedByFirstName = assignedByUser.FirstName,
                                 AssignedByLastName = assignedByUser.LastName,
                                 AssignedByEmail = assignedByUser.Email,
                                 StartedAt = userProject.StartedAt,
                                 AddedAt = userProject.AddedAt,
                                 Status = userProject.Status
                             };

                return result.ToList();
            }
        }



    }
}
