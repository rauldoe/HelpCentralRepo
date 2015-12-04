using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSoft.HCApp.Business
{
    public abstract class BusinessBase : IBusiness
    {
        public BusinessContext Context { get; set; }

        protected BusinessBase(BusinessContext context)
        { Context = context; }
    }
}
