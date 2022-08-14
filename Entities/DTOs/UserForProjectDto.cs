using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //proje liderleri ve adminlerin ,calisanlarin projelere ne zaman
    //basladigini gormeleri icin
    public class UserForProjectDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string JobTitleName { get; set; }
        public DateTime StartedAt { get; set; }
        public string AssignedByFirstName { get; set; }
        public string AssignedByLastName { get; set; }
        public string AssignedByEmail { get; set; }
    }
}
