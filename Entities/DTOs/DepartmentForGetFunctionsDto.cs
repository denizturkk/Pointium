using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class DepartmentForGetFunctionsDto
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string DepartmentName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
