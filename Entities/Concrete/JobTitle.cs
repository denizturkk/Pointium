using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class JobTitle:IEntity
    {
        public int Id { get; set; }
        public string JobTitleName { get; set; }
        public string Explanation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
