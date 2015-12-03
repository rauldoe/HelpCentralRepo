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
            get { return Helper.GetPersonType(Data.persontypeid ?? BusinessUtility.UnknownId); }
            set { Data.persontypeid = value.persontypeid; }
        }

        public gender GenderType {
            get { return Helper.GetGender(Data.gender ?? BusinessUtility.UnknownId); }
            set { Data.gender = value.genderid; }
        }
        public geniestatus GenieStatusType {
            get { return Helper.GetGenieStatus(Data.geniestatusid ?? BusinessUtility.UnknownId); }
            set { Data.geniestatusid = value.geniestatusid; }
        }
        public IEnumerable<geniestatus> GenieStatusList { get { return Helper.GenieStatusList; } }
        public GenieBusiness(BusinessUtility helper, genie data) : base(helper)
        {
            Data = data;
        }
    }
}
