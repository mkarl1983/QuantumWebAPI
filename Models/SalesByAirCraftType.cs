using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumWebAPI.Models
{
    public class SalesByAirCraftType
    {
        public string InvoiceNumber { get; set; }
        public DateTime PostDate { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string ChargeType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string ApplicationCode { get; set; }
        public bool HasApplicationCode { get; set; }
        
    }


    public class SalesByAirCraftTypeStats
    {
      
        public decimal TotalSalesAmount { get; set; }
        public string AirCraftType { get; set; }
        public double Percentage { get; set; }
        public string ImageName { get; set; }
    }
}
