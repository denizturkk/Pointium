using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectForGetFunctionsDto : IDto
    {

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string Explanation { get; set; }
        public DateTime StartedAt { get; set; }
        public bool Status { get; set; }
        public int LeadById { get; set; }
        public string LeadByFirstName { get; set; }
        public string LeadByLastName { get; set; }
        public string leadByEMail { get; set; }
        public int AssignedById { get; set; }
        public string AssignerFirstName { get; set; }
        public string AssignerLastName { get; set; }
        public string AssignerMail { get; set; }
       

       

    }
}
