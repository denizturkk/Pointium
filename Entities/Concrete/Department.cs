using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public  class Department:IEntity
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
