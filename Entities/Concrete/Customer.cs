using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsDeleted { get; set; }


    }
}
