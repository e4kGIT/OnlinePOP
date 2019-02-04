using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public partial class tblonline_attributes
    {
        [NotMapped]
        public List<helperTypelookup> Typelookup
        {
            get
            {
                var rawData = this.FieldTypeLookup.Split(',');
                List<helperTypelookup> data = new List<helperTypelookup>();
                for (int i=0; i<rawData.Length;i++)
                {
                    var helper = new helperTypelookup();
                    helper.ID = i;
                    helper.Value = rawData[i].ToString();
                    data.Add(helper);
                }
                return data;
            }
        }
    }
    public class helperTypelookup
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}
