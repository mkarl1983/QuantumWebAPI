//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuntumDB.QuantumModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVC_DETAIL
    {
        public INVC_DETAIL()
        {
            this.INVC_DETAIL1 = new HashSet<INVC_DETAIL>();
            this.INVC_DETAIL11 = new HashSet<INVC_DETAIL>();
            this.STOCK_RESERVATIONS = new HashSet<STOCK_RESERVATIONS>();
            this.RC_DETAIL = new HashSet<RC_DETAIL>();
        }
    
        public decimal IND_AUTO_KEY { get; set; }
        public Nullable<decimal> SOD_AUTO_KEY { get; set; }
        public Nullable<decimal> CNC_AUTO_KEY { get; set; }
        public decimal INH_AUTO_KEY { get; set; }
        public Nullable<decimal> SYSUR_AUTO_KEY { get; set; }
        public Nullable<decimal> EXCHANGE_RATE { get; set; }
        public System.DateTime INVOICE_DATE { get; set; }
        public decimal ITEM_NUMBER { get; set; }
        public Nullable<System.DateTime> SHIP_DATE { get; set; }
        public string SO_UDF_001 { get; set; }
        public string NOTES { get; set; }
        public Nullable<decimal> QTY_SHIP { get; set; }
        public Nullable<decimal> QTY_BACK_ORDER { get; set; }
        public Nullable<decimal> UNIT_COST { get; set; }
        public Nullable<decimal> UNIT_PRICE { get; set; }
        public Nullable<decimal> TAX_RATE { get; set; }
        public Nullable<decimal> PNM_AUTO_KEY { get; set; }
        public Nullable<decimal> CORE_CHARGE { get; set; }
        public string CLOSED_UPDATE { get; set; }
        public Nullable<decimal> AGN_AUTO_KEY { get; set; }
        public Nullable<decimal> TAX_AMOUNT { get; set; }
        public string CALC_TAX { get; set; }
        public string DAILY_LEASE_METHOD { get; set; }
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        public Nullable<decimal> QTY_RETURNED { get; set; }
        public Nullable<decimal> QTY_RETURNED_TOTAL { get; set; }
        public Nullable<decimal> SPN_AUTO_KEY { get; set; }
        public Nullable<decimal> SCC_AUTO_KEY { get; set; }
        public string BILL_CORE_CHARGE { get; set; }
        public string CUST_REF { get; set; }
        public string PART_MERGE { get; set; }
        public string UPDATE_FROM_STR { get; set; }
        public Nullable<decimal> CUSTOMER_PRICE { get; set; }
        public string CONVERTED { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public string PRINT_NONSTOCK_FLAG { get; set; }
        public Nullable<decimal> CMC_AUTO_KEY { get; set; }
        public Nullable<decimal> SPN_OVERRIDE { get; set; }
        public Nullable<decimal> CMC_OVERRIDE { get; set; }
        public Nullable<decimal> IND_ORIGINAL { get; set; }
        public Nullable<decimal> IND_CREDITED { get; set; }
        public Nullable<decimal> SMD_AUTO_KEY { get; set; }
        public Nullable<decimal> QTY_ORDERED { get; set; }
        public Nullable<decimal> DSC_AUTO_KEY { get; set; }
        public string PACKAGE_OVERRIDE { get; set; }
        public string ROUTE_CODE { get; set; }
        public string ROUTE_DESC { get; set; }
        public Nullable<decimal> SPN_AUTO_KEY2 { get; set; }
        public Nullable<decimal> CMC_AUTO_KEY2 { get; set; }
        public Nullable<decimal> SPN_OVERRIDE2 { get; set; }
        public Nullable<decimal> CMC_OVERRIDE2 { get; set; }
        public Nullable<decimal> CORE_CHARGE_TAX_RATE { get; set; }
        public Nullable<decimal> PDL_AUTO_KEY { get; set; }
        public Nullable<decimal> WQD_AUTO_KEY { get; set; }
        public string SET_CUSTOMER_PRICE { get; set; }
        public Nullable<decimal> MKT_IND { get; set; }
        public string MKT_NOTES { get; set; }
        public string SDF_IND_001 { get; set; }
        public string SDF_IND_002 { get; set; }
        public string SDF_IND_003 { get; set; }
        public string SDF_IND_004 { get; set; }
        public string SDF_IND_005 { get; set; }
        public string SDF_IND_006 { get; set; }
        public string SDF_IND_007 { get; set; }
        public string SDF_IND_008 { get; set; }
        public string SDF_IND_009 { get; set; }
        public string SDF_IND_010 { get; set; }
        public Nullable<decimal> FOREIGN_CORE_CHARGE { get; set; }
        public string EXPORTED { get; set; }
        public Nullable<decimal> DPT_REVENUE { get; set; }
        public string SKIP_SYNC { get; set; }
        public string DO_RULE { get; set; }
        public Nullable<decimal> WOB_AUTO_KEY { get; set; }
        public Nullable<decimal> RPP_AUTO_KEY { get; set; }
        public Nullable<decimal> CONVERSION_ID { get; set; }
        public string CI_EXCHANGE { get; set; }
        public Nullable<System.DateTime> LEASE_PERIOD_START { get; set; }
        public Nullable<System.DateTime> LEASE_PERIOD_END { get; set; }
        public string AP_CREATED { get; set; }
        public Nullable<decimal> STC_AUTO_KEY { get; set; }
        public Nullable<decimal> ELC_AUTO_KEY { get; set; }
    
        public virtual AGENT AGENT { get; set; }
        public virtual COMMISSION_CODES COMMISSION_CODES { get; set; }
        public virtual COMMISSION_CODES COMMISSION_CODES1 { get; set; }
        public virtual COMMISSION_CODES COMMISSION_CODES2 { get; set; }
        public virtual COMMISSION_CODES COMMISSION_CODES3 { get; set; }
        public virtual ICollection<INVC_DETAIL> INVC_DETAIL1 { get; set; }
        public virtual INVC_DETAIL INVC_DETAIL2 { get; set; }
        public virtual ICollection<INVC_DETAIL> INVC_DETAIL11 { get; set; }
        public virtual INVC_DETAIL INVC_DETAIL3 { get; set; }
        public virtual ICollection<STOCK_RESERVATIONS> STOCK_RESERVATIONS { get; set; }
        public virtual INVC_HEADER INVC_HEADER { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER { get; set; }
        public virtual ICollection<RC_DETAIL> RC_DETAIL { get; set; }
        public virtual RO_PIECE_PARTS RO_PIECE_PARTS { get; set; }
        public virtual SO_CATEGORY_CODES SO_CATEGORY_CODES { get; set; }
        public virtual SM_DETAIL SM_DETAIL { get; set; }
        public virtual SO_DETAIL SO_DETAIL { get; set; }
        public virtual STOCK_CATEGORY_CODES STOCK_CATEGORY_CODES { get; set; }
        public virtual SYS_USERS SYS_USERS { get; set; }
    }
}
