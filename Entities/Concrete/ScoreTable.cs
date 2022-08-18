using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ScoreTable :IEntity
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public bool Status { get; set; }
        public bool Type { get; set; }
    }
}
