using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserProjectDayDal:EfEntityRepositoryBase<UserProjectDay,PointiumContext>,IUserProjectDayDal
    {

        public List<UserProjectDayForGetFunctionsDto> GetMonthly(int userProjectId, int year, byte month)
        {
            using (var context = new PointiumContext())
            {

                var result = from userProjectDay in context.UserProjectDays
                             join day in context.Days
                             on userProjectDay.DayId equals day.Id
                             where day.CalendarMonth == month
                             where day.CalendarYear == year

                             join userProject in context.UserProjects
                             on userProjectDay.UserProjectId equals userProject.Id

                             join userProjectDayApproval in context.UserProjectDayApprovals
                             on userProjectDay.UserProjectDayApprovalId equals userProjectDayApproval.Id

                             join scoreTable in context.ScoreTables
                             on userProjectDay.ScoreTableId equals scoreTable.Id


                             where userProjectDay.UserProjectId == userProjectId


                             select new UserProjectDayForGetFunctionsDto
                             {
                                Id = userProjectDay.Id,
                                DayId=userProjectDay.DayId,
                                CalendarDate = day.CalendarDate,
                                DayOfWeekName = day.DayOfWeekName,
                                FullMonthName = day.FullMonthName,
                                CalendarDay=day.CalendarDay,
                                MonthNameCd=day.MonthNameCD,
                                HolidayFlag=day.HolidayFlag,
                                ScoreTableId=scoreTable.Id,
                                ScoreTableExplanation=scoreTable.Explanation,
                                UserProjectId=userProject.Id,
                                UserProjectDayApprovalId=userProjectDayApproval.Id,
                                UserProjectDayApprovalName=userProjectDayApproval.Name,
                                CreatedAt=userProjectDay.CreatedAt,
                                Explanation=userProjectDay.Explanation,
                             };

                return result.ToList();

   




            }
        }

    }
}
