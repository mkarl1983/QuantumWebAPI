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
    
    public partial class SM_HEADER
    {
        public SM_HEADER()
        {
            this.SM_DETAIL = new HashSet<SM_DETAIL>();
            this.SM_HISTORY = new HashSet<SM_HISTORY>();
        }
    
        public decimal SMH_AUTO_KEY { get; set; }
        public Nullable<decimal> SMB_AUTO_KEY { get; set; }
        public Nullable<decimal> SVC_AUTO_KEY { get; set; }
        public Nullable<decimal> SMS_AUTO_KEY { get; set; }
        public Nullable<decimal> CMP_AUTO_KEY { get; set; }
        public Nullable<decimal> SYSUR_AUTO_KEY { get; set; }
        public Nullable<decimal> SOH_AUTO_KEY { get; set; }
        public Nullable<decimal> CST_AUTO_KEY { get; set; }
        public string SM_NUMBER { get; set; }
        public string CERT_NUMBER { get; set; }
        public string TRACKING_NUMBER { get; set; }
        public string OPEN_FLAG { get; set; }
        public string AIRWAY_BILL { get; set; }
        public string FLIGHT_NUMBER { get; set; }
        public Nullable<System.DateTime> FLIGHT_DATE { get; set; }
        public Nullable<System.DateTime> SHIP_DATE { get; set; }
        public Nullable<System.DateTime> ENTRY_DATE { get; set; }
        public Nullable<System.DateTime> ETA_DATE_TIME { get; set; }
        public string TOTAL_WEIGHT { get; set; }
        public string NUMBER_OF_PACKAGES { get; set; }
        public string HOUSE_AIRWAY_BILL { get; set; }
        public string FOB { get; set; }
        public string NOTES { get; set; }
        public string ATTENTION { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string FAX_NUMBER { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string BILL_NAME { get; set; }
        public string BILL_ADDRESS1 { get; set; }
        public string BILL_ADDRESS2 { get; set; }
        public string BILL_ADDRESS3 { get; set; }
        public string BILL_ADDRESS4 { get; set; }
        public string BILL_ADDRESS5 { get; set; }
        public string SHIP_NAME { get; set; }
        public string SHIP_ADDRESS1 { get; set; }
        public string SHIP_ADDRESS2 { get; set; }
        public string SHIP_ADDRESS3 { get; set; }
        public string SHIP_ADDRESS4 { get; set; }
        public string SHIP_ADDRESS5 { get; set; }
        public Nullable<decimal> INH_AUTO_KEY { get; set; }
        public Nullable<decimal> ROH_AUTO_KEY { get; set; }
        public Nullable<decimal> FREIGHT_CHARGE { get; set; }
        public string PACKER_NAME { get; set; }
        public string SM_UDF_001 { get; set; }
        public string SM_UDF_002 { get; set; }
        public string SM_UDF_003 { get; set; }
        public string SM_UDF_004 { get; set; }
        public Nullable<decimal> UOM_AUTO_KEY { get; set; }
        public Nullable<decimal> POH_AUTO_KEY { get; set; }
        public Nullable<decimal> WHS_FROM { get; set; }
        public Nullable<decimal> WHS_TO { get; set; }
        public Nullable<decimal> SVA_AUTO_KEY { get; set; }
        public string HAZMAT_NOTES { get; set; }
        public string SDF_SMH_001 { get; set; }
        public string SDF_SMH_002 { get; set; }
        public string SDF_SMH_003 { get; set; }
        public string SDF_SMH_004 { get; set; }
        public string SDF_SMH_005 { get; set; }
        public string SDF_SMH_006 { get; set; }
        public string SDF_SMH_007 { get; set; }
        public string SDF_SMH_008 { get; set; }
        public string SDF_SMH_009 { get; set; }
        public string SDF_SMH_010 { get; set; }
        public Nullable<decimal> WOO_AUTO_KEY { get; set; }
        public Nullable<decimal> CUR_AUTO_KEY { get; set; }
        public Nullable<decimal> CMP_DROP_SHIP { get; set; }
        public Nullable<decimal> CST_DROP_SHIP { get; set; }
        public Nullable<decimal> COC_AUTO_KEY { get; set; }
        public Nullable<decimal> COD_AMOUNT { get; set; }
        public string COD_COLLECTION_TYPE { get; set; }
        public string COD_ADD_CHARGES { get; set; }
        public string INSIDE_PICKUP { get; set; }
        public string INSIDE_DELIVERY { get; set; }
        public string SATURDAY_PICKUP { get; set; }
        public string SATURDAY_DELIVERY { get; set; }
        public string SIGNATURE_OPTION { get; set; }
        public string MASTER_FORM_ID { get; set; }
        public string NAFTA { get; set; }
        public Nullable<decimal> DTC_AUTO_KEY { get; set; }
        public Nullable<decimal> SOD_AUTO_KEY { get; set; }
        public string FROM_ADDR1 { get; set; }
        public string FROM_ADDR2 { get; set; }
        public string FROM_CITY { get; set; }
        public string FROM_STATE { get; set; }
        public string FROM_ZIP { get; set; }
        public Nullable<decimal> FROM_COC { get; set; }
        public string TO_ADDR1 { get; set; }
        public string TO_ADDR2 { get; set; }
        public string TO_CITY { get; set; }
        public string TO_STATE { get; set; }
        public string TO_ZIP { get; set; }
        public Nullable<decimal> SYSNL_AUTO_KEY { get; set; }
        public Nullable<decimal> MSG_AK_ASN { get; set; }
        public Nullable<System.DateTime> ASN_SENT { get; set; }
        public Nullable<System.DateTime> SMS_UPDATE { get; set; }
        public string TRACK_CHANGES { get; set; }
        public string HOLD { get; set; }
        public Nullable<System.DateTime> DATE_CREATED { get; set; }
        public Nullable<decimal> DUTY_PAYOR { get; set; }
        public string CUSTOMS_BROKER { get; set; }
        public string TRACKING_URL { get; set; }
        public Nullable<decimal> HOR_AUTO_KEY { get; set; }
        public Nullable<decimal> WOB_AUTO_KEY { get; set; }
        public Nullable<decimal> WOB_RETURN { get; set; }
        public Nullable<decimal> WON_AUTO_KEY { get; set; }
        public Nullable<System.DateTime> SHIP_TIMESTAMP { get; set; }
        public Nullable<decimal> SHIP_PRIORITY { get; set; }
        public Nullable<decimal> WOO_WOB_SHIP { get; set; }
        public string DO_NOT_CHARGE_FREIGHT { get; set; }
        public Nullable<decimal> SYSUR_ASSIGNEE { get; set; }
        public string FROM_ADDR3 { get; set; }
        public string FROM_ADDR4 { get; set; }
        public Nullable<decimal> CMP_FREIGHT_FORWARDER { get; set; }
        public Nullable<decimal> CST_FREIGHT_FORWARDER { get; set; }
        public Nullable<decimal> CMP_FOREIGN_CONSIGN { get; set; }
        public Nullable<decimal> CST_FOREIGN_CONSIGN { get; set; }
        public Nullable<decimal> WCH_AUTO_KEY { get; set; }
        public Nullable<decimal> CEM_AUTO_KEY { get; set; }
        public string NON_STOCK { get; set; }
        public string EXPORT_REMARKS { get; set; }
    
        public virtual COMPANy COMPANy { get; set; }
        public virtual COMPANy COMPANy1 { get; set; }
        public virtual CURRENCY CURRENCY { get; set; }
        public virtual PO_HEADER PO_HEADER { get; set; }
        public virtual RO_HEADER RO_HEADER { get; set; }
        public virtual ICollection<SM_DETAIL> SM_DETAIL { get; set; }
        public virtual ICollection<SM_HISTORY> SM_HISTORY { get; set; }
        public virtual SYS_USERS SYS_USERS { get; set; }
        public virtual SM_STATUS SM_STATUS { get; set; }
        public virtual SO_HEADER SO_HEADER { get; set; }
        public virtual SYS_USERS SYS_USERS1 { get; set; }
    }
}
