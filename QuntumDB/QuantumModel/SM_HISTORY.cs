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
    
    public partial class SM_HISTORY
    {
        public decimal SMI_AUTO_KEY { get; set; }
        public Nullable<decimal> SMB_AUTO_KEY { get; set; }
        public string SM_BATCH_NUMBER { get; set; }
        public decimal SMH_AUTO_KEY { get; set; }
        public string SM_NUMBER { get; set; }
        public decimal SMS_AUTO_KEY { get; set; }
        public string STATUS_CODE { get; set; }
        public decimal SMD_AUTO_KEY { get; set; }
        public decimal QTY_SMD { get; set; }
        public decimal STM_AUTO_KEY { get; set; }
        public decimal QTY_STK { get; set; }
        public Nullable<decimal> SOD_REF { get; set; }
        public Nullable<decimal> ROD_REF { get; set; }
        public Nullable<decimal> IND_REF { get; set; }
        public Nullable<decimal> WOO_REF { get; set; }
        public Nullable<decimal> WOB_REF { get; set; }
        public Nullable<decimal> WTT_REF { get; set; }
        public Nullable<decimal> RPP_REF { get; set; }
        public Nullable<decimal> WCD_REF { get; set; }
        public Nullable<decimal> POD_REF { get; set; }
        public Nullable<decimal> PPP_REF { get; set; }
        public Nullable<decimal> STI_REF { get; set; }
        public decimal PNM_AUTO_KEY { get; set; }
        public string PN { get; set; }
        public System.DateTime TRAN_DATE { get; set; }
        public Nullable<decimal> CRQ_AUTO_KEY { get; set; }
    
        public virtual PARTS_MASTER PARTS_MASTER { get; set; }
        public virtual SM_DETAIL SM_DETAIL { get; set; }
        public virtual SM_HEADER SM_HEADER { get; set; }
        public virtual SM_STATUS SM_STATUS { get; set; }
        public virtual STOCK STOCK { get; set; }
    }
}
