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
    
    public partial class RC_DETAIL
    {
        public RC_DETAIL()
        {
            this.RC_SERIAL = new HashSet<RC_SERIAL>();
            this.STOCKs = new HashSet<STOCK>();
        }
    
        public decimal RCD_AUTO_KEY { get; set; }
        public decimal RCH_AUTO_KEY { get; set; }
        public Nullable<decimal> PCC_AUTO_KEY { get; set; }
        public Nullable<decimal> RCS_AUTO_KEY { get; set; }
        public Nullable<decimal> RDC_AUTO_KEY { get; set; }
        public Nullable<decimal> POD_AUTO_KEY { get; set; }
        public Nullable<decimal> SOD_AUTO_KEY { get; set; }
        public Nullable<decimal> EXC_AUTO_KEY { get; set; }
        public Nullable<decimal> IND_AUTO_KEY { get; set; }
        public Nullable<decimal> ROD_AUTO_KEY { get; set; }
        public Nullable<decimal> WOO_AUTO_KEY { get; set; }
        public Nullable<decimal> WCD_AUTO_KEY { get; set; }
        public Nullable<decimal> PNM_AUTO_KEY { get; set; }
        public Nullable<decimal> ALT_PNM_AUTO_KEY { get; set; }
        public Nullable<decimal> WHS_AUTO_KEY { get; set; }
        public Nullable<decimal> LOC_AUTO_KEY { get; set; }
        public string PN { get; set; }
        public string MFG_CODE { get; set; }
        public string PN2 { get; set; }
        public string MFG2 { get; set; }
        public string SERIALIZED { get; set; }
        public Nullable<decimal> QTY { get; set; }
        public Nullable<decimal> QTY_APPR { get; set; }
        public Nullable<decimal> QTY_DENIED { get; set; }
        public Nullable<decimal> QTY_REMAIN { get; set; }
        public Nullable<decimal> QTY_HIST_DENIED { get; set; }
        public Nullable<decimal> QTY_HIST_APPR { get; set; }
        public string RECEIVER_INSTR { get; set; }
        public Nullable<decimal> ITEM_NUMBER { get; set; }
        public Nullable<decimal> CTS_AUTO_KEY { get; set; }
        public Nullable<decimal> CMP_AUTO_KEY { get; set; }
        public Nullable<decimal> CNC_AUTO_KEY { get; set; }
        public Nullable<decimal> STC_AUTO_KEY { get; set; }
        public Nullable<decimal> IFC_AUTO_KEY { get; set; }
        public Nullable<decimal> STR_AUTO_KEY { get; set; }
        public string REMARKS { get; set; }
        public Nullable<System.DateTime> EXP_DATE { get; set; }
        public string OWNER { get; set; }
        public string IC_UDF_005 { get; set; }
        public string IC_UDF_006 { get; set; }
        public string IC_UDF_007 { get; set; }
        public string IC_UDF_008 { get; set; }
        public string IC_UDF_009 { get; set; }
        public string IC_UDF_010 { get; set; }
        public string PART_CERT_NUMBER { get; set; }
        public string TAGGED_BY { get; set; }
        public Nullable<System.DateTime> TAG_DATE { get; set; }
        public Nullable<decimal> UNIT_COST { get; set; }
        public Nullable<decimal> UNIT_PRICE { get; set; }
        public Nullable<decimal> SERIES_NUMBER { get; set; }
        public Nullable<decimal> SERIES_ID { get; set; }
        public Nullable<decimal> CTRL_NUMBER { get; set; }
        public Nullable<decimal> CTRL_ID { get; set; }
        public Nullable<System.DateTime> ENTRY_DATE { get; set; }
        public string REC_TYPE { get; set; }
        public Nullable<decimal> REC_TRAN_ID { get; set; }
        public string NOTES { get; set; }
        public string PRINT_FLAG { get; set; }
        public string FORCE_SPLIT { get; set; }
        public Nullable<decimal> MXP_AUTO_KEY { get; set; }
        public Nullable<decimal> WPT_AUTO_KEY { get; set; }
        public Nullable<decimal> WOB_AUTO_KEY { get; set; }
        public string LOT_APL_RO_COST { get; set; }
        public string LOT_ALW_PRECOST { get; set; }
        public string ORIGINAL_PO_NUMBER { get; set; }
        public string RO_INFO { get; set; }
        public string SHIP_INVC_NUMBER { get; set; }
        public Nullable<decimal> UNIT_FREIGHT_COST { get; set; }
        public string VISIBLE_MKT { get; set; }
        public string SDF_RCD_001 { get; set; }
        public string SDF_RCD_002 { get; set; }
        public string SDF_RCD_003 { get; set; }
        public string SDF_RCD_004 { get; set; }
        public string SDF_RCD_005 { get; set; }
        public string SDF_RCD_006 { get; set; }
        public string SDF_RCD_007 { get; set; }
        public string SDF_RCD_008 { get; set; }
        public string SDF_RCD_009 { get; set; }
        public string SDF_RCD_010 { get; set; }
        public string HOLOGRAM { get; set; }
        public Nullable<System.DateTime> INSPECT_DUE_DATE { get; set; }
        public string AIRWAY_BILL { get; set; }
        public string IN_DEF_REC { get; set; }
        public Nullable<decimal> RRD_AUTO_KEY { get; set; }
        public Nullable<decimal> QTY_PCK_SLIP { get; set; }
        public Nullable<decimal> QTY_COUNTED { get; set; }
        public Nullable<System.DateTime> MFG_DATE { get; set; }
        public string IC_UDF_020 { get; set; }
        public Nullable<System.DateTime> IC_UDF_021 { get; set; }
        public Nullable<System.DateTime> IC_UDF_022 { get; set; }
        public string MFG_LOT_NUM { get; set; }
        public Nullable<decimal> QTY_ORIG_PO { get; set; }
        public Nullable<decimal> IC_UDN_001 { get; set; }
        public Nullable<decimal> IC_UDN_002 { get; set; }
        public Nullable<decimal> IC_UDN_003 { get; set; }
        public Nullable<decimal> IC_UDN_004 { get; set; }
        public Nullable<decimal> IC_UDN_005 { get; set; }
        public Nullable<decimal> IC_UDN_006 { get; set; }
        public Nullable<decimal> IC_UDN_007 { get; set; }
        public Nullable<decimal> IC_UDN_008 { get; set; }
        public Nullable<decimal> IC_UDN_009 { get; set; }
        public Nullable<decimal> IC_UDN_010 { get; set; }
        public string CALIB_REMARKS { get; set; }
        public string CALIB_REF_MASTER { get; set; }
        public string CALIB_REF_INSTR { get; set; }
        public string TEMP_SERIAL_NUMBER { get; set; }
        public Nullable<decimal> SMD_AUTO_KEY { get; set; }
        public string VOID_FLAG { get; set; }
        public Nullable<System.DateTime> ARRIVAL_DATE { get; set; }
        public Nullable<decimal> VENDOR_PRICE { get; set; }
        public Nullable<decimal> ACT_AUTO_KEY { get; set; }
        public Nullable<decimal> EIT_AUTO_KEY { get; set; }
        public Nullable<decimal> TTP_AUTO_KEY { get; set; }
        public string IC_UDF_023 { get; set; }
        public Nullable<decimal> IC_UDL_001 { get; set; }
        public Nullable<decimal> IC_UDL_002 { get; set; }
        public Nullable<decimal> IC_UDL_003 { get; set; }
        public Nullable<decimal> IC_UDL_004 { get; set; }
        public Nullable<decimal> IC_UDL_005 { get; set; }
        public string IC_UDL_005_TXT { get; set; }
        public Nullable<decimal> COC_ORIGIN { get; set; }
        public Nullable<decimal> CSS_AUTO_KEY { get; set; }
    
        public virtual INVC_DETAIL INVC_DETAIL { get; set; }
        public virtual PART_CONDITION_CODES PART_CONDITION_CODES { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER1 { get; set; }
        public virtual PO_DETAIL PO_DETAIL { get; set; }
        public virtual RC_HEADER RC_HEADER { get; set; }
        public virtual ICollection<RC_SERIAL> RC_SERIAL { get; set; }
        public virtual RC_STATUS RC_STATUS { get; set; }
        public virtual RO_DETAIL RO_DETAIL { get; set; }
        public virtual SM_DETAIL SM_DETAIL { get; set; }
        public virtual SO_DETAIL SO_DETAIL { get; set; }
        public virtual ICollection<STOCK> STOCKs { get; set; }
        public virtual STOCK_RESERVATIONS STOCK_RESERVATIONS { get; set; }
    }
}
