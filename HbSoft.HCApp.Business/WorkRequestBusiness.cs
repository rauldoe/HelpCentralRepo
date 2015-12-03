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

        public GenieBusiness Genie
        {
            get { return new GenieBusiness(Helper, Helper.Db.genies.Where(i => i.genieid == Data.genieid).FirstOrDefault() ?? new genie()); }
        }

        public ScheduleBusiness Schedule {
            get { return new ScheduleBusiness(Helper, Helper.Db.schedules.Where(i=>i.scheduleid == Data.scheduleid).FirstOrDefault()?? new schedule()); }
        }
        public requesttype RequestType { get { return Helper.GetRequestType(Data.requesttypeid ?? BusinessUtility.UnknownId); } }

        public List<servicetype> ServiceTypeList
        {
            get { return Helper.ConvertServiceTypeDataToList(Data.servicetypelistid); }
        }
        public WorkRequestBusiness(BusinessUtility helper, workrequest data) : base(helper)
        {
            Data = data;
        }
    }
}
