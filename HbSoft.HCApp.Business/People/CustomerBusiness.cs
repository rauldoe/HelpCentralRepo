using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class CustomerBusiness : PersonBusiness
    {
        public customer Data { get; set; }
        public persontype PersonType {
            get { return Context.Helper.GetPersonType(Data.persontypeid ?? BusinessUtility.UnknownId); }
            set { Data.persontypeid = value.persontypeid; }
        }
        public gender GenderType {
            get { return Context.Helper.GetGender(Data.gender ?? BusinessUtility.UnknownId); }
            set { Data.gender = value.genderid; }
        }

        public CustomerBusiness(BusinessContext context, customer data) : base(context)
        {
            Data = data;
        }
    }
}
