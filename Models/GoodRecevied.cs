using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumWebAPI.Models
{
    public class GoodRecevied
    {
        public string GRN { get; set; }
        public DateTime Date { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string OrderType { get; set; }
        public string OrderNumber { get; set; }
        public decimal Qty { get; set; }
        public string SerialNumber { get; set; }
        public string Customer { get; set; }
    }
}
