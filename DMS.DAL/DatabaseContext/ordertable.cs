//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMS.DAL.DatabaseContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class ordertable
    {
        public string oid { get; set; }
        public int id { get; set; }
        public int oqty { get; set; }
        public decimal oprice { get; set; }
        public decimal oamount { get; set; }
        public int pid { get; set; }
        public Nullable<System.DateTime> odate { get; set; }
    
        public virtual regcustomer regcustomer { get; set; }
        public virtual producttable producttable { get; set; }
    }
}