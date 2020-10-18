using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumWebAPI.Models
{
    //public class SaleOrderToQuoteRatio
    //{
    //    public double TodayOrderToQuoteRatio { get; set; }
    //    public double MTDOrderToQuoteRatio { get; set; }
    //    public double YTDOrderToQuoteRatio { get; set; }
    //    public double QTDOrderToQuoteRatio { get; set; }
    //    public double LTMOrderToQuoteRatio { get; set; }

    //}

    //public class PurchaseOrderTotals
    //{
    //    public decimal TodayPurchaseOrder { get; set; }
    //    public decimal MTDPurchaseOrder { get; set; }
    //    public decimal YTDPurchaseOrder { get; set; }
    //    public decimal QTDPurchaseOrder { get; set; }
    //    public decimal LTMPurchaseOrder { get; set; }

    //}

    //public class RepairOrderTotals
    //{
    //    public decimal TodayRepairOrder { get; set; }
    //    public decimal MTDRepairOrder { get; set; }
    //    public decimal YTDRepairOrder { get; set; }
    //    public decimal QTDRepairOrder { get; set; }
    //    public decimal LTMRepairOrder { get; set; }
    //}

    //public class SalesOrderTotals
    //{
    //    public decimal TodayTotals { get; set; }
    //    public decimal MTDTotals { get; set; }
    //    public decimal YTDTotals { get; set; }
    //    public decimal QTDTotals { get; set; }
    //    public decimal LTMTotals { get; set; }
    //}

    //public class InvoiceTotals
    //{
    //    public decimal TodayTotals { get; set; }
    //    public decimal MTDTotals { get; set; }
    //    public decimal YTDTotals { get; set; }
    //    public decimal QTDTotals { get; set; }
    //    public decimal LTMTotals { get; set; }
    //}

    public class AllTotals
    {
        public decimal TodayTotals { get; set; }
        public decimal MTDTotals { get; set; }
        public decimal YTDTotals { get; set; }
        public decimal QTDTotals { get; set; }
        public decimal LTMTotals { get; set; }
    }

    public class AllRatioTotals
    {
        public double TodayTotals { get; set; }
        public double MTDTotals { get; set; }
        public double YTDTotals { get; set; }
        public double QTDTotals { get; set; }
        public double LTMTotals { get; set; }
    }





}