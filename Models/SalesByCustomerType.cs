using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumWebAPI.Models
{
    public class SalesByCustomerType
    {
        public string SalesNumber { get; set; }
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalPrice { get; set; }

        public string Customer { get; set; }
        public string Vendor { get; set; }
        public string Airline { get; set; }
        public string MROFBO { get; set; }
        public string BrokerSerious { get; set; }
        public string Broker { get; set; }
        public string OEM { get; set; }
        public string MROAPPD { get; set; }
        public string SUPAPPD { get; set; }
      
    }
}
