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
        public GenieBusiness(BusinessContext context, genie data) : base(context)
        {
            Data = data;
        }
    }
}
