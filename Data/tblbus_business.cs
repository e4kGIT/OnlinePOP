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
    
    public partial class tblbus_business
    {
        public tblbus_business()
        {
            this.tblcustom_entity = new HashSet<tblcustom_entity>();
            this.tblfsk_style_suppliers = new HashSet<tblfsk_style_suppliers>();
            this.tblpop_order_header = new HashSet<tblpop_order_header>();
        }
    
        public string CompanyID { get; set; }
        public string BusinessID { get; set; }
        public string BusType { get; set; }
        public string Name { get; set; }
        public Nullable<int> Country_Currency { get; set; }
        public bool Live { get; set; }
        public Nullable<int> AnalysisCodeID { get; set; }
        public string Default_Nominal { get; set; }
        public string Factoring_No { get; set; }
        public string Comments { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string CoupleID { get; set; }
        public bool IsExtract { get; set; }
    
        public virtual ICollection<tblcustom_entity> tblcustom_entity { get; set; }
        public virtual ICollection<tblfsk_style_suppliers> tblfsk_style_suppliers { get; set; }
        public virtual ICollection<tblpop_order_header> tblpop_order_header { get; set; }
    }
}