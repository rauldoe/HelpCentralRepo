using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCApp.Models
{
    public class GenieViewModel
    {
        public HCApp.genie Genie {get; set;}
        public List<HCApp.workrequest> WorkRequestList { get; set; }
    }
}