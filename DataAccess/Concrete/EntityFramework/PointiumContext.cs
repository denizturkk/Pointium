using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class PointiumContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-04SRGOA\MSSQLSERVER01;Database=Pointium; Trusted_Connection=True") ;
        }

        //From Entities
         public DbSet<Project> Projects  { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserProjectDay> UserProjectDays { get; set; }
        public DbSet<UserProjectDayApproval> UserProjectDayApprovals { get; set; }
        public DbSet<ScoreTable> ScoreTables { get; set; }
        public DbSet<Day> Days { get; set; }
       


        //From Core
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }





    }
}
