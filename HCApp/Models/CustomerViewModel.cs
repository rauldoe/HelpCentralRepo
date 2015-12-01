using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCApp.Models
{
    public class CustomerViewModel
    {
        public HCApp.customer Customer { get; set; }
        public List<HCApp.order> OrderList { get; set; }
    }
}