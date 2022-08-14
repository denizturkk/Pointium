using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserDetail:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public string NationalIdentity { get; set; }
        public string GSM { get; set; }
        public DateTime StartedAt { get; set; }
        //public DateTime ModifiedAt { get; set; }
    }
}
