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
    
    public partial class PO_CATEGORY_CODES
    {
        public PO_CATEGORY_CODES()
        {
            this.STOCKs = new HashSet<STOCK>();
            this.PO_DETAIL = new HashSet<PO_DETAIL>();
        }
    
        public decimal POC_AUTO_KEY { get; set; }
        public Nullable<decimal> GLS_AUTO_KEY { get; set; }
        public string PO_CATEGORY_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string CANNOT_MODIFY { get; set; }
        public decimal SEQUENCE { get; set; }
        public string ROUTE_CODE { get; set; }
        public string ROUTE_DESC { get; set; }
        public string SDF_POC_001 { get; set; }
        public string SDF_POC_002 { get; set; }
        public string SDF_POC_003 { get; set; }
        public string SDF_POC_004 { get; set; }
        public string SDF_POC_005 { get; set; }
        public string SDF_POC_006 { get; set; }
        public string SDF_POC_007 { get; set; }
        public string SDF_POC_008 { get; set; }
        public string SDF_POC_009 { get; set; }
        public string SDF_POC_010 { get; set; }
    
        public virtual ICollection<STOCK> STOCKs { get; set; }
        public virtual ICollection<PO_DETAIL> PO_DETAIL { get; set; }
    }
}
