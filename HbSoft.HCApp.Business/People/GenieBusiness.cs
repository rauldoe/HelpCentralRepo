using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class GenieBusiness : PersonBusiness
    {
        public genie Data { get; set; }
        public persontype PersonType
        {
            get { return Context.Helper.GetPersonType(Data.persontypeid ?? BusinessUtility.UnknownId); }
            set { Data.persontypeid = value.persontypeid; }
        }
        public gender GenderType
        {
            get { return Context.Helper.GetGender(Data.gender ?? BusinessUtility.UnknownId); }
            set { Data.gender = value.genderid; }
        }
        public geniestatus GenieStatusType {
            get { return Context.Helper.GetGenieStatus(Data.geniestatusid ?? BusinessUtility.UnknownId); }
            set { Data.geniestatusid = value.geniestatusid; }
        }
        public IEnumerable<geniestatus> GenieStatusList { get { return Context.Helper.GenieStatusList; } }

        private IEnumerable<WorkRequestBusiness> _workRequestList;
        public IEnumerable<WorkRequestBusiness> WorkRequest
        {
            get
            {
                if (_workRequestList == null)
                {
                    _workRequestList = Context.WorkRequestList.Where(i => i.Data.genieid == Data.genieid).ToList();
                }

                return _workRequestList;
            }
        }
        public GenieBusiness(BusinessContext context, genie data) : base(context)
        {
            Data = data;
        }

        public static GenieBusiness Login(BusinessContext context, string userId, string password)
        {
            return context.GenieList.Where(i => i.Data.email == userId && i.Data.password == password).FirstOrDefault() ?? new GenieBusiness(context, new genie());
        }
    }
}
