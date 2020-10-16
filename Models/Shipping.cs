using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumWebAPI.Models
{
    public class Shipping
    {
        public string ShipNumber { get; set; }
        public DateTime Date { get; set; }
        public string PartNumber { get; set; }
        public string Customer { get; set; }
        public string PO { get; set; }
        public string Status { get; set; }
        public string RO { get; set; }
        public string SO { get; set; }
        public decimal Priority { get; set; }
        public string IsHazmat { get; set; }
        public string SalesPerson { get; set; }

    }
}
