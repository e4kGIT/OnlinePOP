using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public partial class tblpop_order_detail
    {
        [DisplayName("O/S Qty")]
        public int OSQty { get
            {
               // int OrgOS = (int)this.OrdQty;

                return ((int)this.OrdQty - this.tbleav_entity_attribute_value_orderdetail_ref.Sum(s => s.Qty));
            }
        }
    }  
}
