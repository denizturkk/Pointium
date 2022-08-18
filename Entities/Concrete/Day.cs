using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Day:IEntity
    {
        public int Id { get; set; }
        public DateTime CalendarDate { get; set; }
        public byte CalendarDay { get; set; }
        public byte CalendarMonth { get; set; }
        public byte CalendarQuarter { get; set; }
        public int CalendarYear { get; set; }
        public byte DayOfWeekNum { get; set; }
        public string DayOfWeekName { get; set; }
        public string DateNum { get; set; }
        public string QuarterCD { get; set; }
        public string MonthNameCD { get; set; }
        public string FullMonthName { get; set; }
        public string HolidayName { get; set; }
        public bool HolidayFlag { get; set; }


    }
}
