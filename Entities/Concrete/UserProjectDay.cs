using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserProjectDay:IEntity
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public int ScoreTableId { get; set; }
        public int UserProjectId { get; set; }
        public int UserProjectApprovalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Explanation { get; set; }
    }
}
