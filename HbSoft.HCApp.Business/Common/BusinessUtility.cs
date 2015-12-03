using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class BusinessUtility
    {
        public static readonly int UnknownId = -1;

        public helpcentraldbEntities Db { get; private set; }
        public BusinessUtility(helpcentraldbEntities db)
        {
            Db = db;
        }

        public IEnumerable<persontype> PersonTypeList {get { return Db.persontypes.ToList(); } }
        public IEnumerable<gender> GenderTypeList {get { return Db.genders.ToList(); } }
        public IEnumerable<geniestatus> GenieStatusList { get { return Db.geniestatuses.ToList(); } }
        public IEnumerable<servicetype> ServiceTypeList { get { return Db.servicetypes.ToList(); } }
        public IEnumerable<orderstatus> OrderStatusList { get { return Db.orderstatuses.ToList(); } }
        public IEnumerable<requesttype> RequestTypeList { get { return Db.requesttypes.ToList(); } }
        public IEnumerable<scheduletype> ScheduleTypeList { get { return Db.scheduletypes.ToList(); } }
        public persontype GetPersonType(int personTypeId)
        { return Db.persontypes.Where(i=>i.persontypeid == personTypeId).FirstOrDefault()??new persontype(); }

        public gender GetGender(int genderId)
        { return Db.genders.Where(i => i.genderid == genderId).FirstOrDefault() ?? new gender(); }
        
        public geniestatus GetGenieStatus(int genieStatusId)
        { return Db.geniestatuses.Where(i => i.geniestatusid == genieStatusId).FirstOrDefault()??new geniestatus(); }

        public servicetype GetServiceType(int serviceTypeId)
        { return Db.servicetypes.Where(i => i.servicetypeid == serviceTypeId).FirstOrDefault() ?? new servicetype(); }
        public orderstatus GetOrderStatus(int orderStatusId)
        { return Db.orderstatuses.Where(i => i.orderstatusid == orderStatusId).FirstOrDefault() ?? new orderstatus(); }

        public requesttype GetRequestType(int requestTypeId)
        { return Db.requesttypes.Where(i => i.requesttypeid == requestTypeId).FirstOrDefault() ?? new requesttype(); }

        public scheduletype GetScheduleType(int scheduleTypeId)
        { return Db.scheduletypes.Where(i => i.scheduletypeid == scheduleTypeId).FirstOrDefault() ?? new scheduletype(); }

        public List<DayOfWeek> ConvertDayOfWeekDataToList(string data)
        {
            string[] dataList = (data ?? string.Empty).Split(',');
            var list = new List<DayOfWeek>();

            foreach (var i in dataList)
            { list.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), i)); }

            return list;
        }

        public List<servicetype> ConvertServiceTypeDataToList(string data)
        {
            string[] dataList = (data ?? string.Empty).Split(',');
            var list = new List<servicetype>();

            foreach (var i in dataList)
            { list.Add(Db.servicetypes.Where(j=>j.servicetypeid==Convert.ToInt32(i)).FirstOrDefault()??new servicetype()); }

            return list;
        }
        public DateTime GetDate(DateTime dt)
        { return dt.Date; }

        public TimeSpan GetTime(DateTime dt)
        { return dt.TimeOfDay; }

    }
}

