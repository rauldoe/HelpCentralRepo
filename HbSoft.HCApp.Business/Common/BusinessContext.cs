using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HbSoft.HCApp.Data;

namespace HbSoft.HCApp.Business
{
    public class BusinessContext : IDisposable
    {
        #region Disposable Pattern Code
        bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BusinessContext()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                Helper.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null
            _customerList.Clear();
            _customerList = null;
            _genieList.Clear();
            _genieList = null;
            _schedulerList.Clear();
            _schedulerList = null;
            _orderList.Clear();
            _orderList = null;
            _scheduleList.Clear();
            _scheduleList = null;
            _workRequestList.Clear();
            _workRequestList = null;

            _disposed = true;
        }
        #endregion

        public BusinessUtility Helper { get; private set; }

        public BusinessContext(helpcentraldbEntities db)
        {
            Helper = new BusinessUtility(db);
        }
         
        public BusinessContext()
        {
            var db = new helpcentraldbEntities();
            Helper = new BusinessUtility(db);
        }

        private List<CustomerBusiness> _customerList;
        public IEnumerable<CustomerBusiness> CustomerList
        {
            get {
                if (_customerList == null)
                {
                    _customerList = new List<CustomerBusiness>();
                    
                    foreach(var i in Helper.Db.customers)
                    {
                        _customerList.Add(GetCustomer(i));
                    }
                }

                return _customerList;
            }
        }

        private List<GenieBusiness> _genieList;
        public IEnumerable<GenieBusiness> GenieList
        {
            get
            {
                if (_genieList == null)
                {
                    _genieList = new List<GenieBusiness>();

                    foreach (var i in Helper.Db.genies)
                    {
                        _genieList.Add(GetGenie(i));
                    }
                }

                return _genieList;
            }
        }

        private List<SchedulerBusiness> _schedulerList;
        public IEnumerable<SchedulerBusiness> SchedulerList
        {
            get
            {
                if (_schedulerList == null)
                {
                    _schedulerList = new List<SchedulerBusiness>();

                    foreach (var i in Helper.Db.schedulers)
                    {
                        _schedulerList.Add(GetScheduler(i));
                    }
                }

                return _schedulerList;
            }
        }

        private List<OrderBusiness> _orderList;
        public IEnumerable<OrderBusiness> OrderList
        {
            get
            {
                if (_orderList == null)
                {
                    _orderList = new List<OrderBusiness>();

                    foreach (var i in Helper.Db.orders)
                    {
                        _orderList.Add(GetOrder(i));
                    }
                }

                return _orderList;
            }
        }

        private List<ScheduleBusiness> _scheduleList;
        public IEnumerable<ScheduleBusiness> ScheduleList
        {
            get
            {
                if (_scheduleList == null)
                {
                    _scheduleList = new List<ScheduleBusiness>();

                    foreach (var i in Helper.Db.schedules)
                    {
                        _scheduleList.Add(GetSchedule(i));
                    }
                }

                return _scheduleList;
            }
        }
        private List<WorkRequestBusiness> _workRequestList;
        public IEnumerable<WorkRequestBusiness> WorkRequestList
        {
            get
            {
                if (_workRequestList == null)
                {
                    _workRequestList = new List<WorkRequestBusiness>();

                    foreach (var i in Helper.Db.workrequests)
                    {
                        _workRequestList.Add(GetWorkRequest(i));
                    }
                }

                return _workRequestList;
            }
        }
        public CustomerBusiness GetCustomer(customer data)
        { return new CustomerBusiness(this, data); }
        public GenieBusiness GetGenie(genie data)
        { return new GenieBusiness(this, data); }

        public SchedulerBusiness GetScheduler(scheduler data)
        { return new SchedulerBusiness(this, data); }

        public OrderBusiness GetOrder(order data)
        { return new OrderBusiness(this, data); }
        public ScheduleBusiness GetSchedule(schedule data)
        { return new ScheduleBusiness(this, data); }
        public WorkRequestBusiness GetWorkRequest(workrequest data)
        { return new WorkRequestBusiness(this, data); }

        public CustomerBusiness CreateCustomer()
        {
            var item = new CustomerBusiness(this, new customer());
            Helper.Db.customers.Add(item.Data);
            return item;
        }

        public GenieBusiness CreateGenie()
        {
            var item = new GenieBusiness(this, new genie());
            Helper.Db.genies.Add(item.Data);
            return item;
        }
        public SchedulerBusiness CreateScheduler()
        {
            var item = new SchedulerBusiness(this, new scheduler());
            Helper.Db.schedulers.Add(item.Data);
            return item;
        }
        public OrderBusiness CreateOrder()
        {
            var item = new OrderBusiness(this, new order());
            Helper.Db.orders.Add(item.Data);
            return item;
        }
        public ScheduleBusiness CreateSchedule()
        {
            var item = new ScheduleBusiness(this, new schedule());
            Helper.Db.schedules.Add(item.Data);
            return item;
        }
        public WorkRequestBusiness CreateWorkRequest()
        {
            var item = new WorkRequestBusiness(this, new workrequest());
            Helper.Db.workrequests.Add(item.Data);
            return item;
        }

        public void Save()
        {
            Helper.Db.SaveChanges();
        }
    }
}
