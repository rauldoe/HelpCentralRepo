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
        public bool IsUnknown { get { return Data.customerid == BusinessUtility.UnknownId; } }
        public customer Data { get; set; }
        public persontype PersonType {
            get { return Context.Helper.GetPersonType(Data.persontypeid ?? BusinessUtility.UnknownId); }
            set { Data.persontypeid = value.persontypeid; }
        }
        public gender GenderType {
            get { return Context.Helper.GetGender(Data.gender ?? BusinessUtility.UnknownId); }
            set { Data.gender = value.genderid; }
        }

        private IEnumerable<OrderBusiness> _orderList;
        public IEnumerable<OrderBusiness> OrderList
        {
            get {
                if (_orderList == null)
                {
                    _orderList = Context.OrderList.Where(i => i.Customer.Data.customerid == Data.customerid).ToList();
                }

                return _orderList;
            }
        }
        public CustomerBusiness(BusinessContext context, customer data) : base(context)
        {
            Data = data;
        }

        public static CustomerBusiness Login(BusinessContext context, string userId, string password)
        {
            return context.CustomerList.Where(i => i.Data.email == userId && i.Data.password == password).FirstOrDefault() ?? new CustomerBusiness(context, new customer());
        }
    }
}
