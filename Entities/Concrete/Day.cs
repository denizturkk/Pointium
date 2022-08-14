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
        public string CalendarDay { get; set; }
        public string CalendarMonth { get; set; }
        public string CalendarQuarter { get; set; }
        public string CalendarYear { get; set; }
        public string DayOfWeekNum { get; set; }
        public string DayOfWeekName { get; set; }
        public string DateNum { get; set; }
        public string QuarterCD { get; set; }
        public string MonthNameCD { get; set; }
        public string FullMonthName { get; set; }
        public string HolidayName { get; set; }
        public string HolidayFlag { get; set; }


    }
}
