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
    
    public partial class PI_STATUS
    {
        public PI_STATUS()
        {
            this.PI_HEADER = new HashSet<PI_HEADER>();
        }
    
        public decimal PIS_AUTO_KEY { get; set; }
        public string STATUS_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string OPEN_FLAG { get; set; }
        public Nullable<decimal> SEQUENCE { get; set; }
        public string SDF_PIS_001 { get; set; }
        public string SDF_PIS_002 { get; set; }
        public string SDF_PIS_003 { get; set; }
        public string SDF_PIS_004 { get; set; }
        public string SDF_PIS_005 { get; set; }
        public string SDF_PIS_006 { get; set; }
        public string SDF_PIS_007 { get; set; }
        public string SDF_PIS_008 { get; set; }
        public string SDF_PIS_009 { get; set; }
        public string SDF_PIS_010 { get; set; }
    
        public virtual ICollection<PI_HEADER> PI_HEADER { get; set; }
    }
}