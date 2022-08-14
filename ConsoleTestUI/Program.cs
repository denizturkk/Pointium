using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleTestUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            ProjectManager projectManager = new ProjectManager( new EfProjectDal());

            Project sample = new Project();
            sample.ProjectName = "sampleProject";
            sample.StartedAt= DateTime.Now;
        
            sample.Status = true;
            sample.Explanation = "first test project";
            sample.CustomerId = 1;
            sample.AssignedById = 2;
            sample.Id = 1;
            sample.LeadById = 3;
    
        }
            */


            // var returnValue = projectManager.Add(sample);
            // Console.WriteLine(returnValue.Message+ " " +returnValue.Success);


            /*
              foreach (var item in projectManager.GetAll().Data)
              {
                  Console.WriteLine(item.Name+ " " +item.Explanation + " " + item.AssignedById + " " + item.LeadById);
              }
            */



            //foreach (var item in projectManager.GetByLeadId(3).Data)
            //{
            //    Console.WriteLine(item.Name + " " + item.Explanation + " " + item.AssignedById + " " + item.LeadById);
            //}



        }

    
    }
}
