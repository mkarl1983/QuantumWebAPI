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
    
    public partial class RO_PIECE_PARTS
    {
        public RO_PIECE_PARTS()
        {
            this.CQ_DETAIL = new HashSet<CQ_DETAIL>();
            this.INVC_DETAIL = new HashSet<INVC_DETAIL>();
            this.SM_DETAIL = new HashSet<SM_DETAIL>();
            this.SO_DETAIL = new HashSet<SO_DETAIL>();
            this.STOCK_RESERVATIONS = new HashSet<STOCK_RESERVATIONS>();
        }
    
        public decimal RPP_AUTO_KEY { get; set; }
        public decimal PNM_AUTO_KEY { get; set; }
        public decimal ROD_AUTO_KEY { get; set; }
        public Nullable<decimal> QTY { get; set; }
        public Nullable<decimal> QTY_RESERVED { get; set; }
        public Nullable<decimal> QTY_ISSUED { get; set; }
        public string CUSTOMER_STOCK { get; set; }
        public string SDF_RPP_001 { get; set; }
        public string SDF_RPP_002 { get; set; }
        public string SDF_RPP_003 { get; set; }
        public string SDF_RPP_004 { get; set; }
        public string SDF_RPP_005 { get; set; }
        public string SDF_RPP_006 { get; set; }
        public string SDF_RPP_007 { get; set; }
        public string SDF_RPP_008 { get; set; }
        public string SDF_RPP_009 { get; set; }
        public string SDF_RPP_010 { get; set; }
        public Nullable<decimal> QUOTED_COST { get; set; }
        public Nullable<decimal> FOREIGN_QUOTED_COST { get; set; }
        public Nullable<decimal> EXCHANGE_RATE { get; set; }
    
        public virtual ICollection<CQ_DETAIL> CQ_DETAIL { get; set; }
        public virtual ICollection<INVC_DETAIL> INVC_DETAIL { get; set; }
        public virtual PARTS_MASTER PARTS_MASTER { get; set; }
        public virtual RO_DETAIL RO_DETAIL { get; set; }
        public virtual ICollection<SM_DETAIL> SM_DETAIL { get; set; }
        public virtual ICollection<SO_DETAIL> SO_DETAIL { get; set; }
        public virtual ICollection<STOCK_RESERVATIONS> STOCK_RESERVATIONS { get; set; }
    }
}
