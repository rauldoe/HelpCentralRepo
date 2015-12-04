using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class WorkRequestBusiness : BusinessBase
    {
        public workrequest Data { get; set; }

        private GenieBusiness _genie;
        public GenieBusiness Genie
        {
            get {
                if (_genie == null)
                {
                    _genie = Context.GenieList.Where(i => i.Data.genieid == Data.genieid).FirstOrDefault() ?? new GenieBusiness(Context, new genie());
                }

                return _genie;
            }

            set
            {
                if (Context.GenieList.Where(i=>i.Data.genieid == value.Data.genieid).Count() > 0)
                {
                    _genie = value;
                    Data.genieid = _genie.Data.genieid;
                }
            }
        }

        private ScheduleBusiness _schedule;
        public ScheduleBusiness Schedule {
            get
            {
                if (_schedule == null)
                {
                    _schedule = Context.ScheduleList.Where(i => i.Data.scheduleid == Data.scheduleid).FirstOrDefault() ?? new ScheduleBusiness(Context, new schedule());
                }

                return _schedule;
            }

            set
            {
                if (Context.ScheduleList.Where(i => i.Data.scheduleid == value.Data.scheduleid).Count() > 0)
                {
                    _schedule = value;
                    Data.scheduleid = _schedule.Data.scheduleid;
                }
            }
        }
        public requesttype RequestType { get { return Context.Helper.GetRequestType(Data.requesttypeid ?? BusinessUtility.UnknownId); } }

        public List<servicetype> ServiceTypeList
        {
            get { return Context.Helper.ConvertServiceTypeDataToList(Data.servicetypelistid); }
        }
        public WorkRequestBusiness(BusinessContext context, workrequest data) : base(context)
        {
            Data = data;
        }
    }
}
