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
    
    public partial class SM_STATUS
    {
        public SM_STATUS()
        {
            this.SM_HEADER = new HashSet<SM_HEADER>();
            this.SM_HISTORY = new HashSet<SM_HISTORY>();
        }
    
        public decimal SMS_AUTO_KEY { get; set; }
        public Nullable<decimal> WON_AUTO_KEY { get; set; }
        public string STATUS_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string OPEN_FLAG { get; set; }
        public string CREATE_INVOICE { get; set; }
        public string POST_INVOICE { get; set; }
        public Nullable<decimal> SEQUENCE { get; set; }
        public string PRINT_PICK_TICKET { get; set; }
        public string PRINT_C_OF_C { get; set; }
        public string PRINT_ADVICE_NOTE { get; set; }
        public string PRINT_PART_TAG { get; set; }
        public string PRINT_CUSTOM_INVC { get; set; }
        public string PRINT_DESPATCH_NOTE { get; set; }
        public string PRINT_SHIP_LABEL { get; set; }
        public string PRINT_HAZARD_MATERIAL { get; set; }
        public string ALLOW_AUTO_COMBINE { get; set; }
        public string PROCESS_RETURNS { get; set; }
        public string PRINT_INVOICE { get; set; }
        public string PRINT_MATERIAL_CERT { get; set; }
        public string PRINT_IMAGES { get; set; }
        public string PRINTER_NAME { get; set; }
        public string SDF_SMS_001 { get; set; }
        public string SDF_SMS_002 { get; set; }
        public string SDF_SMS_003 { get; set; }
        public string SDF_SMS_004 { get; set; }
        public string SDF_SMS_005 { get; set; }
        public string SDF_SMS_006 { get; set; }
        public string SDF_SMS_007 { get; set; }
        public string SDF_SMS_008 { get; set; }
        public string SDF_SMS_009 { get; set; }
        public string SDF_SMS_010 { get; set; }
        public string RELIEVE_WO_SL { get; set; }
        public string PRINT_PO_RETURN { get; set; }
        public string PRINT_CORE_RETURN { get; set; }
        public string PRINT_RO_DOCUMENT { get; set; }
        public string PRINT_INVOICE_STYLE { get; set; }
        public string PRINT_PICK_TICKET_STYLE { get; set; }
        public string PRINT_DESPATCH_NOTE_STYLE { get; set; }
        public string PRINT_HAZMAT_STYLE { get; set; }
        public string PRINT_ADVICE_NOTE_STYLE { get; set; }
        public string PRINT_PART_TAG_STYLE { get; set; }
        public string PRINT_PO_RETURN_STYLE { get; set; }
        public string PRINT_SHIP_LABEL_STYLE { get; set; }
        public string PRINT_CORE_RETURN_STYLE { get; set; }
        public string PRINT_MAT_CERT_STYLE { get; set; }
        public string PRINT_RO_DOC_STYLE { get; set; }
        public string PRINT_CUSTOM_INVC_STYLE { get; set; }
        public string PRINT_C_OF_C_STYLE { get; set; }
        public string PRINT_CUSTOM_INVC_STYLE_SM { get; set; }
        public string PRINT_DESPATCH_NOTE_STYLE_SM { get; set; }
        public string XFER_CONS_STATION { get; set; }
        public Nullable<decimal> VALIDATE_DUE_DATE { get; set; }
        public string SHIPPING_QUEUE { get; set; }
        public string CANCEL_SM_ORDER { get; set; }
        public string EDI_ONLY_STATUS { get; set; }
        public string CM_CREATE_OPEN { get; set; }
        public string CM_CLOSE_CHG { get; set; }
        public Nullable<decimal> PJM_AUTO_KEY { get; set; }
        public string CONTACT_NOTES { get; set; }
        public string ISSUE_PO_PIECE_PARTS { get; set; }
        public string ISSUE_WO_PARTS { get; set; }
        public string SET_CORE_DUE_DATE { get; set; }
        public string DO_NOT_PRINT_C_OF_C_FOR_RO { get; set; }
        public string PROCESS_CUSTOMS { get; set; }
        public string FLAGSHIP { get; set; }
        public string CREATE_PRO_FORMA { get; set; }
        public string PRINT_WO_BILLING { get; set; }
        public string POST_WO_BILLING { get; set; }
        public string PRINT_WO_BILLING_STYLE { get; set; }
        public Nullable<decimal> WCS_AUTO_KEY { get; set; }
        public string CREATE_WO_BILLING { get; set; }
    
        public virtual ICollection<SM_HEADER> SM_HEADER { get; set; }
        public virtual ICollection<SM_HISTORY> SM_HISTORY { get; set; }
    }
}
