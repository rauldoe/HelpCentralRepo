//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderhistory
    {
        public int orderhistoryid { get; set; }
        public Nullable<int> orderid { get; set; }
        public Nullable<int> genieid { get; set; }
        public Nullable<System.DateTime> assigneddate { get; set; }
        public Nullable<System.DateTime> genieacceptdate { get; set; }
        public Nullable<System.DateTime> genierejectdate { get; set; }
        public string genierejectreason { get; set; }
        public Nullable<System.DateTime> interviewdate { get; set; }
        public string interviewresult { get; set; }
    }
}
