using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserProjectDayForGetFunctionsDto:IDto
    {
        public int Id { get; set; }
       
        public int DayId { get; set; }
        public DateTime CalendarDate { get; set; }
        public string DayOfWeekName { get; set; }
        public string FullMonthName { get; set; }
        public byte CalendarDay { get; set; }
        public string MonthNameCd { get; set; }
        public bool HolidayFlag { get; set; }
       
        public int ScoreTableId { get; set; }
        public string ScoreTableExplanation { get; set; }

        public int UserProjectId { get; set; }

        public int UserProjectDayApprovalId { get; set; }
        public string UserProjectDayApprovalName { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Explanation { get; set; }



    }
}
