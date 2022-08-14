using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserProject:IEntity 
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int AssignedById { get; set; }
        public bool Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
