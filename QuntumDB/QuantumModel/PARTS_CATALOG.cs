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
    
    public partial class PARTS_CATALOG
    {
        public decimal PNC_AUTO_KEY { get; set; }
        public Nullable<decimal> PNM_AUTO_KEY { get; set; }
        public System.DateTime MFG_PRICE_DATE { get; set; }
        public string PN { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> LIST_PRICE { get; set; }
        public string MFG_CODE { get; set; }
        public string MFG_DESCRIPTION { get; set; }
        public Nullable<decimal> MFG_DEPOSIT { get; set; }
        public string COND_CODE { get; set; }
        public string UOM_CODE { get; set; }
        public string MFG_DISCOUNT { get; set; }
        public string NOTES { get; set; }
        public Nullable<decimal> QTY { get; set; }
        public string CONVERTED { get; set; }
        public Nullable<decimal> DSC_AUTO_KEY { get; set; }
        public string AVREF_COMMENTS { get; set; }
        public Nullable<decimal> FOREIGN_LIST_PRICE { get; set; }
        public Nullable<decimal> CUR_AUTO_KEY { get; set; }
        public Nullable<decimal> EXCHANGE_RATE { get; set; }
        public string AVREF_FLAG { get; set; }
        public string NSN { get; set; }
        public string SDF_PNC_001 { get; set; }
        public string SDF_PNC_002 { get; set; }
        public string SDF_PNC_003 { get; set; }
        public string SDF_PNC_004 { get; set; }
        public string SDF_PNC_005 { get; set; }
        public string SDF_PNC_006 { get; set; }
        public string SDF_PNC_007 { get; set; }
        public string SDF_PNC_008 { get; set; }
        public string SDF_PNC_009 { get; set; }
        public string SDF_PNC_010 { get; set; }
        public Nullable<decimal> CONVERSION_ID { get; set; }
        public string VENDOR_NAME { get; set; }
        public string VENDOR_CAGE_CODE { get; set; }
        public Nullable<decimal> LEAD_TIME { get; set; }
        public Nullable<System.DateTime> EXP_DATE { get; set; }
        public string REFERENCE_LINK { get; set; }
        public string PRICE_TYPE { get; set; }
        public Nullable<decimal> QTY_MINIMUM_ORDER { get; set; }
    
        public virtual CURRENCY CURRENCY { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER { get; set; }
    }
}
