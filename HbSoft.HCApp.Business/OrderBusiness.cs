using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class OrderBusiness : BusinessBase
    {
        public order Data { get; set; }
        public servicetype ServiceType {
            get { return Context.Helper.GetServiceType(Data.servicetypeid ?? BusinessUtility.UnknownId); }
            set { Data.servicetypeid = value.servicetypeid; }
        }
        public orderstatus OrderStatus {
            get { return Context.Helper.GetOrderStatus(Data.orderstatusid ?? BusinessUtility.UnknownId); }
            set { Data.orderstatusid = value.orderstatusid; }
        }

        private CustomerBusiness _customer;
        public CustomerBusiness Customer {
            get
            {
                if (_customer == null)
                {
                    _customer = Context.CustomerList.Where(i => i.Data.customerid == Data.customerid).FirstOrDefault() ?? new CustomerBusiness(Context, new customer());
                }

                return _customer;
            }

            set
            {
                if (Context.CustomerList.Where(i => i.Data.customerid == value.Data.customerid).Count() > 0)
                {
                    _customer = value;
                    Data.customerid = _customer.Data.customerid;
                }
            }
        }

        private GenieBusiness _preferredGenie;
        public GenieBusiness PreferredGenie {
            get
            {
                if (_preferredGenie == null)
                {
                    _preferredGenie = Context.GenieList.Where(i => i.Data.genieid == Data.perferredgenieid).FirstOrDefault() ?? new GenieBusiness(Context, new genie());
                }

                return _preferredGenie;
            }

            set
            {
                if (Context.GenieList.Where(i => i.Data.genieid == value.Data.genieid).Count() > 0)
                {
                    _preferredGenie = value;
                    Data.perferredgenieid = _preferredGenie.Data.genieid;
                }
            }
        }
        public OrderBusiness(BusinessContext context, order data) : base(context)
        {
            Data = data;
        }
    }
}
