using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class BusinessContext
    {
        public BusinessUtility Helper { get; private set; }

        public BusinessContext(helpcentraldbEntities db)
        {
            Helper = new BusinessUtility(db);
        }

        public CustomerBusiness GetCustomer(customer data)
        { return new CustomerBusiness(Helper, data); }
        public GenieBusiness GetGenie(genie data)
        { return new GenieBusiness(Helper, data); }

        public SchedulerBusiness GetScheduler(scheduler data)
        { return new SchedulerBusiness(Helper, data); }

        public OrderBusiness GetOrder(order data)
        { return new OrderBusiness(Helper, data); }
        public ScheduleBusiness GetSchedule(schedule data)
        { return new ScheduleBusiness(Helper, data); }
        public WorkRequestBusiness GetWorkRequest(workrequest data)
        { return new WorkRequestBusiness(Helper, data); }

    }
}
