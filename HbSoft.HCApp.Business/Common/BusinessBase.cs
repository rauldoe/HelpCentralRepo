using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSoft.HCApp.Business
{
    public abstract class BusinessBase : IBusiness
    {
        public BusinessUtility Helper { get; set; }

        protected BusinessBase(BusinessUtility helper)
        { Helper = helper; }
    }
}
