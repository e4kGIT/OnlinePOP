using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class StatusByBusiness
    {
        [NotMapped]
        public string Status { get; set; }
        [NotMapped]
        public string Username{ get; set; }
        [NotMapped]
        public DateTime? LastUpdate { get; set; }
        [NotMapped]
        public bool IsCurrent { get; set; }
        [NotMapped]
        public int StatusID { get; set; }
        [NotMapped]
        public int SeqNo { get; set; }
        [NotMapped]
        public bool IShow { get; set; }
        [NotMapped]
        public int OrderNo { get; set; }
    }
}
