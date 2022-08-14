using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectForUserDto:IDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }      
        public int AssignedById { get; set; }
        public string AssignedByFirstName { get; set; }
        public string AssignedByLastName { get; set; }
        public string AssignedByEmail { get; set; }
        public bool Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime AddedAt { get; set; }
    }
    
}
