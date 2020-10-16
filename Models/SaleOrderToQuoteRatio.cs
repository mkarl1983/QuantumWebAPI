using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumWebAPI.Models
{
    public class SaleOrderToQuoteRatio
    {
        public double TodayOrderToQuoteRatio { get; set; }
        public double MTDOrderToQuoteRatio { get; set; }
        public double YTDOrderToQuoteRatio { get; set; }
        public double QTDOrderToQuoteRatio { get; set; }
        public double LTMOrderToQuoteRatio { get; set; }

    }


    public class PurchaseOrderTotals
    {
        public decimal TodayPurchaseOrder { get; set; }
        public decimal MTDPurchaseOrder { get; set; }
        public decimal YTDPurchaseOrder { get; set; }
        public decimal QTDPurchaseOrder { get; set; }
        public decimal LTMPurchaseOrder { get; set; }

    }

    public class RepairOrderTotals
    {
        public decimal TodayRepairOrder { get; set; }
        public decimal MTDRepairOrder { get; set; }
        public decimal YTDRepairOrder { get; set; }
        public decimal QTDRepairOrder { get; set; }
        public decimal LTMRepairOrder { get; set; }
    }
}