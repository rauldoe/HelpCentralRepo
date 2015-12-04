using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class ScheduleBusiness : BusinessBase
    {
        public schedule Data { get; set; }

        public scheduletype ScheduleType { get { return Context.Helper.GetScheduleType(Data.scheduletypeid ?? BusinessUtility.UnknownId); } }

        public List<DayOfWeek> DaysOfTheWeekList {
            get { return Context.Helper.ConvertDayOfWeekDataToList(Data.daysoftheweeklist); }
        }
        public ScheduleBusiness(BusinessContext context, schedule data) : base(context)
        {
            Data = data;
        }
    }
}
