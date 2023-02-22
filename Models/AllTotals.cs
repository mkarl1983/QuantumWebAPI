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


    public class TotalsModel
    {
        public string SerialNumber { get; set; }
        public DateTime QueryDate { get; set; }
        public decimal Total { get; set; }

    }

    public class AllTotals
    {
        public decimal TodayTotals { get; set; }
        public decimal MTDTotals { get; set; }
        public decimal YTDTotals { get; set; }
        public decimal QTDTotals { get; set; }
        public decimal LTMTotals { get; set; }


        public decimal TodayTotals_UK { get; set; }
        public decimal MTDTotals_UK { get; set; }
        public decimal YTDTotals_UK { get; set; }
        public decimal QTDTotals_UK { get; set; }
        public decimal LTMTotals_UK { get; set; }

        public decimal TodayTotals_USA { get; set; }
        public decimal MTDTotals_USA { get; set; }
        public decimal YTDTotals_USA { get; set; }
        public decimal QTDTotals_USA { get; set; }
        public decimal LTMTotals_USA { get; set; }



    }

    public class AllRatioTotals
    {
        public double TodayTotals { get; set; }
        public double MTDTotals { get; set; }
        public double YTDTotals { get; set; }
        public double QTDTotals { get; set; }
        public double LTMTotals { get; set; }

        public double TodayTotals_UK { get; set; }
        public double MTDTotals_UK { get; set; }
        public double YTDTotals_UK { get; set; }
        public double QTDTotals_UK { get; set; }
        public double LTMTotals_UK { get; set; }

        public double TodayTotals_USA { get; set; }
        public double MTDTotals_USA { get; set; }
        public double YTDTotals_USA { get; set; }
        public double QTDTotals_USA { get; set; }
        public double LTMTotals_USA { get; set; }
    }

    public enum CountryEnum
    {
        Global = 0,
        Uk = 1,
        Usa = 2
    }

    public static class CommonConstants
    {
        public const string RO_UK = "ERO";
        public const string RO_UK_Old = "R";
        public const string RO_USA = "ARO";
        public const string RO_USA_BRO = "BRO";
        public const string RO_UK_FRO = "FRO";

        public const string SO_UK = "ESO";
        public const string SO_UK_Old = "S";
        public const string SO_USA = "ASO";
        public const string SO_USA_BSO = "BSO";
        public const string SO_UK_FSO = "FSO";

        public const string PO_UK = "EPO";
        public const string PO_UK_Old = "P";
        public const string PO_USA = "APO";

        public const string INV_UK = "EIN";
        public const string INV_UK_Old = "IN";
        public const string INV_USA = "AIN";
        public const string INV_USA_BIN = "BIN";
        public const string INV_UK_FIN = "FIN";


        public const string CQ_UK = "EQ";
        public const string CQ_UK_Old = "Q";
        public const string CQ_UK_UKQ = "UKQ";
        public const string CQ_USA = "AQ";

    }
}