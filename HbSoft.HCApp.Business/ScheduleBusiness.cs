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

        public scheduletype ScheduleType { get { return Helper.GetScheduleType(Data.scheduletypeid ?? BusinessUtility.UnknownId); } }

        public List<DayOfWeek> DaysOfTheWeekList {
            get { return Helper.ConvertDayOfWeekDataToList(Data.daysoftheweeklist); }
        }
        public ScheduleBusiness(BusinessUtility helper, schedule data) : base(helper)
        {
            Data = data;
        }

        public ScheduleBusiness(BusinessUtility helper) : base(helper)
        {
            Data = new schedule();
            Helper.Db.schedules.Add(Data);
        }
    }
}
