﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCApp.Models
{
    public class SchedulerViewModel
    {
        public List<CustomerViewModel> CustomerViewModelList { get; set; }
        public List<GenieViewModel> GenieViewModelList { get; set; } 
    }
}