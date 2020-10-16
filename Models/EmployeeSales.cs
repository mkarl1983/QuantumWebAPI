using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumWebAPI.Models
{
    public class EmployeeSales
    {
        public string Employeee { get; set; }
        public int SalesCount { get; set; }
        public decimal TotalSalesUnitPrice { get; set; }
    }
}