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
    
    public partial class PO_STATUS
    {
        public PO_STATUS()
        {
            this.PO_HEADER = new HashSet<PO_HEADER>();
        }
    
        public decimal PST_AUTO_KEY { get; set; }
        public string STATUS_CODE { get; set; }
        public string STATUS_TYPE { get; set; }
        public Nullable<decimal> SEQUENCE { get; set; }
        public string DESCRIPTION { get; set; }
    
        public virtual ICollection<PO_HEADER> PO_HEADER { get; set; }
    }
}
