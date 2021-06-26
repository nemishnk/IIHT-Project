using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PriceModel
    {
        public string CompanyCode { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int value { get; set; }
    }
}
