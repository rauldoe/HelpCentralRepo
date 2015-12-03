using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class PersonBusiness : BusinessBase
    {
        public IEnumerable<persontype> PersonTypeList { get { return Helper.PersonTypeList; } }
        public IEnumerable<gender> GenderTypeList { get { return Helper.GenderTypeList; } }
        protected PersonBusiness(BusinessUtility helper) : base(helper)
        {
        }
    }
}
