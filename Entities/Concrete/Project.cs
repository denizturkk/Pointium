using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Project:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LeadById { get; set; }
        public int AssignedById { get; set; }
        public string ProjectName { get; set; }    
        public bool Status { get; set; }
        public string Explanation { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
