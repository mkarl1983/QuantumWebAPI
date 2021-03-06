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
    
    public partial class PO_DETAIL
    {
        public PO_DETAIL()
        {
            this.STOCKs = new HashSet<STOCK>();
            this.SM_DETAIL = new HashSet<SM_DETAIL>();
            this.STOCKs1 = new HashSet<STOCK>();
            this.STOCKs2 = new HashSet<STOCK>();
            this.STOCK_RESERVATIONS = new HashSet<STOCK_RESERVATIONS>();
            this.RC_DETAIL = new HashSet<RC_DETAIL>();
        }
    
        public decimal POD_AUTO_KEY { get; set; }
        public decimal PNM_AUTO_KEY { get; set; }
        public Nullable<decimal> PCC_AUTO_KEY { get; set; }
        public Nullable<decimal> UOM_AUTO_KEY { get; set; }
        public decimal POH_AUTO_KEY { get; set; }
        public Nullable<decimal> ALT_PNM_AUTO_KEY { get; set; }
        public Nullable<decimal> SYSUR_AUTO_KEY { get; set; }
        public string BUY_AS_TYPE { get; set; }
        public System.DateTime ENTRY_DATE { get; set; }
        public Nullable<decimal> EXCHANGE_RATE { get; set; }
        public decimal ITEM_NUMBER { get; set; }
        public Nullable<System.DateTime> LAST_DELIVERY_DATE { get; set; }
        public Nullable<System.DateTime> NEXT_DELIVERY_DATE { get; set; }
        public string NOTES { get; set; }
        public Nullable<decimal> QTY_BACK_ORDER { get; set; }
        public Nullable<decimal> QTY_ORDERED { get; set; }
        public Nullable<decimal> QTY_REC { get; set; }
        public Nullable<decimal> UNIT_COST { get; set; }
        public Nullable<decimal> STR_AUTO_KEY { get; set; }
        public string CLOSED_UPDATE { get; set; }
        public Nullable<decimal> VENDOR_PRICE { get; set; }
        public Nullable<decimal> PRI_AUTO_KEY { get; set; }
        public Nullable<decimal> QTY_REC_INCR { get; set; }
        public Nullable<decimal> QTY_RET_TOT { get; set; }
        public Nullable<decimal> QTY_RET_INCR { get; set; }
        public Nullable<decimal> ORIG_POD { get; set; }
        public Nullable<decimal> REC_TRAN_ID { get; set; }
        public Nullable<decimal> POC_AUTO_KEY { get; set; }
        public string SOD_LINK { get; set; }
        public string WOB_LINK { get; set; }
        public string IQ_SO { get; set; }
        public string IQ_PN { get; set; }
        public string IQ_SERIAL { get; set; }
        public Nullable<decimal> IQ_ITEM_NO { get; set; }
        public Nullable<decimal> SOD_EXCH_CHG { get; set; }
        public string RECEIVER_INSTR { get; set; }
        public string CONVERTED { get; set; }
        public Nullable<decimal> SYSUR_AUTH { get; set; }
        public Nullable<decimal> STM_RETURNED { get; set; }
        public Nullable<decimal> DSC_AUTO_KEY { get; set; }
        public string EXT_AP_NUMBER { get; set; }
        public Nullable<System.DateTime> EXT_AP_DATE { get; set; }
        public Nullable<decimal> WHS_AUTO_KEY { get; set; }
        public string PRINT_FLAG { get; set; }
        public Nullable<decimal> LIST_PRICE { get; set; }
        public string RR_SPLIT { get; set; }
        public string COST_ADJUSTED { get; set; }
        public string LOT_FLAG { get; set; }
        public string REMARKS { get; set; }
        public Nullable<decimal> PRD_AUTO_KEY { get; set; }
        public string ROUTE_CODE { get; set; }
        public string ROUTE_DESC { get; set; }
        public Nullable<decimal> PRIORITY { get; set; }
        public Nullable<decimal> SMD_AUTO_KEY { get; set; }
        public Nullable<System.DateTime> COMMIT_SHIP_DATE { get; set; }
        public string SDF_POD_001 { get; set; }
        public string SDF_POD_002 { get; set; }
        public string SDF_POD_003 { get; set; }
        public string SDF_POD_004 { get; set; }
        public string SDF_POD_005 { get; set; }
        public string SDF_POD_006 { get; set; }
        public string SDF_POD_007 { get; set; }
        public string SDF_POD_008 { get; set; }
        public string SDF_POD_009 { get; set; }
        public string SDF_POD_010 { get; set; }
        public Nullable<decimal> EST_PRICE { get; set; }
        public string EDI_NUMBER { get; set; }
        public Nullable<decimal> CNC_AUTO_KEY { get; set; }
        public Nullable<decimal> FACTOR { get; set; }
        public Nullable<decimal> QTY_REC_UC { get; set; }
        public string HAS_PIECE_PARTS { get; set; }
        public Nullable<decimal> SHM_AUTO_KEY { get; set; }
        public Nullable<decimal> STC_AUTO_KEY { get; set; }
        public Nullable<System.DateTime> LAST_MODIFIED { get; set; }
        public Nullable<decimal> SYSUR_MODIFIED { get; set; }
        public Nullable<decimal> PRE_TAX_UNIT_COST { get; set; }
        public Nullable<decimal> PRE_TAX_FOREIGN_COST { get; set; }
        public Nullable<decimal> TAX_AMOUNT { get; set; }
        public Nullable<decimal> FOREIGN_TAX_AMOUNT { get; set; }
        public string CALC_TAX { get; set; }
        public Nullable<decimal> WOO_LOT { get; set; }
        public Nullable<System.DateTime> COMMIT_SHIP_DATE2 { get; set; }
        public Nullable<decimal> COC_AUTO_KEY { get; set; }
        public Nullable<decimal> APC_AUTO_KEY { get; set; }
        public Nullable<decimal> CONVERSION_ID { get; set; }
        public string ECC { get; set; }
        public Nullable<decimal> EDI_ACK_COUNTER { get; set; }
        public string EDI_STATUS { get; set; }
        public string EDI_NOTES_LOG { get; set; }
        public Nullable<decimal> TIME_SINCE_NEW { get; set; }
        public Nullable<decimal> CYCLE_SINCE_NEW { get; set; }
        public Nullable<System.DateTime> MFG_DATE { get; set; }
        public Nullable<decimal> TIME_SINCE_OVHL { get; set; }
        public Nullable<decimal> CYCLE_SINCE_OVHL { get; set; }
        public Nullable<System.DateTime> LAST_OVHL { get; set; }
        public Nullable<decimal> TIME_SINCE_INSP { get; set; }
        public Nullable<decimal> CYCLE_SINCE_INSP { get; set; }
        public Nullable<System.DateTime> LAST_INSP { get; set; }
        public Nullable<decimal> TIME_SINCE_REPAIR { get; set; }
        public Nullable<decimal> CYCLE_SINCE_REPAIR { get; set; }
        public string UNKNOWN_LIFE { get; set; }
        public string AUTH_LIFE { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public Nullable<decimal> MSG_AK_ACK { get; set; }
        public Nullable<decimal> MSG_AK_INVC { get; set; }
        public string AIRWAY_BILL { get; set; }
        public string EDI_UPDATE { get; set; }
        public Nullable<decimal> CTD_AUTO_KEY { get; set; }
        public string PURCHASED_FROM_LOT { get; set; }
        public Nullable<decimal> OPM_AUTO_KEY { get; set; }
        public string RO_TYPE { get; set; }
        public Nullable<decimal> RECEIVED_VENDOR_PRICE { get; set; }
        public Nullable<decimal> RECEIVED_UNIT_COST { get; set; }
        public string SDF_POD_011 { get; set; }
        public string SDF_POD_012 { get; set; }
        public string SDF_POD_013 { get; set; }
        public string SDF_POD_014 { get; set; }
        public string SDF_POD_015 { get; set; }
        public string SDF_POD_016 { get; set; }
        public string SDF_POD_017 { get; set; }
        public string SDF_POD_018 { get; set; }
        public string SDF_POD_019 { get; set; }
        public string SDF_POD_020 { get; set; }
        public string SKIP_RR_FLAG { get; set; }
        public Nullable<decimal> WOO_AUTO_KEY { get; set; }
        public Nullable<decimal> QTY_TO_REC { get; set; }
        public Nullable<decimal> CIM_AUTO_KEY { get; set; }
        public Nullable<decimal> CEM_AUTO_KEY { get; set; }
        public Nullable<decimal> GROUP_NUMBER { get; set; }
        public Nullable<decimal> POD_SPLIT_FROM { get; set; }
        public Nullable<decimal> RECEIVED_EXCHANGE_RATE { get; set; }
    
        public virtual APPLICATION_CODES APPLICATION_CODES { get; set; }
        public virtual PART_CONDITION_CODES PART_CONDITION_CODES { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER1 { get; set; }
        public virtual PO_CATEGORY_CODES PO_CATEGORY_CODES { get; set; }
        public virtual ICollection<STOCK> STOCKs { get; set; }
        public virtual ICollection<SM_DETAIL> SM_DETAIL { get; set; }
        public virtual ICollection<STOCK> STOCKs1 { get; set; }
        public virtual ICollection<STOCK> STOCKs2 { get; set; }
        public virtual ICollection<STOCK_RESERVATIONS> STOCK_RESERVATIONS { get; set; }
        public virtual PO_HEADER PO_HEADER { get; set; }
        public virtual ICollection<RC_DETAIL> RC_DETAIL { get; set; }
        public virtual SM_DETAIL SM_DETAIL1 { get; set; }
        public virtual STOCK_CATEGORY_CODES STOCK_CATEGORY_CODES { get; set; }
        public virtual STOCK STOCK { get; set; }
        public virtual SYS_USERS SYS_USERS { get; set; }
    }
}
