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
    
    public partial class tblcore_types
    {
        public tblcore_types()
        {
            this.tbleav_entity_entitytypes = new HashSet<tbleav_entity_entitytypes>();
            this.tblcore_entity_types = new HashSet<tblcore_entity_types>();
        }
    
        public int ID { get; set; }
        public Nullable<int> entity_id { get; set; }
        public string description { get; set; }
        public string Notification { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    
        public virtual tblcore_entities tblcore_entities { get; set; }
        public virtual ICollection<tbleav_entity_entitytypes> tbleav_entity_entitytypes { get; set; }
        public virtual ICollection<tblcore_entity_types> tblcore_entity_types { get; set; }
    }
}
