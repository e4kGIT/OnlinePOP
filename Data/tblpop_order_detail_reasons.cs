//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblpop_order_detail_reasons
    {
        public string CompanyId { get; set; }
        public string WareHouseId { get; set; }
        public int OrderNo { get; set; }
        public int LineNo { get; set; }
        public string Reason { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}
