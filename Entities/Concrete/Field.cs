using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Field:IEntity
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
