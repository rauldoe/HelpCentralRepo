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
            get { return Helper.GetServiceType(Data.servicetypeid ?? BusinessUtility.UnknownId); }
            set { Data.servicetypeid = value.servicetypeid; }
        }
        public orderstatus OrderStatus {
            get { return Helper.GetOrderStatus(Data.orderstatusid ?? BusinessUtility.UnknownId); }
            set { Data.orderstatusid = value.orderstatusid; }
        }

        public CustomerBusiness Customer {
            get { return new CustomerBusiness(Helper, Helper.Db.customers.Where(i => i.customerid == Data.customerid).FirstOrDefault() ?? new customer()); }
            set { Data.customerid = value.Data.customerid; }
        }

        public GenieBusiness PreferredGenie {
            get { return new GenieBusiness(Helper, Helper.Db.genies.Where(i => i.genieid == Data.perferredgenieid).FirstOrDefault() ?? new genie()); }
            set { Data.perferredgenieid = value.Data.genieid; }
        }
        public OrderBusiness(BusinessUtility helper, order data) : base(helper)
        {
            Data = data;
        }
    }
}
