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
    
    public partial class tblcore_attributes
    {
        public tblcore_attributes()
        {
            this.tbleav_entity_attribute = new HashSet<tbleav_entity_attribute>();
            this.tbleav_entity_attribute_custom = new HashSet<tbleav_entity_attribute_custom>();
        }
    
        public int ID { get; set; }
        public string Attribute { get; set; }
        public string AttributeTypeBackend { get; set; }
        public string ControlTypeFrontend { get; set; }
        public string FieldTypeLookup { get; set; }
    
        public virtual ICollection<tbleav_entity_attribute> tbleav_entity_attribute { get; set; }
        public virtual ICollection<tbleav_entity_attribute_custom> tbleav_entity_attribute_custom { get; set; }
    }
}
