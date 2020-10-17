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
    
    public partial class SYS_USERS
    {
        public SYS_USERS()
        {
            this.AP_ACCOUNT = new HashSet<AP_ACCOUNT>();
            this.AP_DETAIL = new HashSet<AP_DETAIL>();
            this.AR_ACCOUNT = new HashSet<AR_ACCOUNT>();
            this.AR_DETAIL = new HashSet<AR_DETAIL>();
            this.COMPANIES = new HashSet<COMPANy>();
            this.COMPANIES1 = new HashSet<COMPANy>();
            this.COMPANIES2 = new HashSet<COMPANy>();
            this.CQ_DETAIL = new HashSet<CQ_DETAIL>();
            this.CQ_HEADER = new HashSet<CQ_HEADER>();
            this.CQ_HEADER1 = new HashSet<CQ_HEADER>();
            this.CURRENCies = new HashSet<CURRENCY>();
            this.INVC_DETAIL = new HashSet<INVC_DETAIL>();
            this.INVC_HEADER = new HashSet<INVC_HEADER>();
            this.INVC_HEADER1 = new HashSet<INVC_HEADER>();
            this.PI_HEADER = new HashSet<PI_HEADER>();
            this.PO_DETAIL = new HashSet<PO_DETAIL>();
            this.PO_HEADER = new HashSet<PO_HEADER>();
            this.PO_HEADER1 = new HashSet<PO_HEADER>();
            this.PO_HEADER2 = new HashSet<PO_HEADER>();
            this.RC_SERIAL = new HashSet<RC_SERIAL>();
            this.RO_DETAIL = new HashSet<RO_DETAIL>();
            this.RO_HEADER = new HashSet<RO_HEADER>();
            this.RO_HEADER1 = new HashSet<RO_HEADER>();
            this.RO_HEADER2 = new HashSet<RO_HEADER>();
            this.RO_PRE_COSTING_CHARGES = new HashSet<RO_PRE_COSTING_CHARGES>();
            this.SM_DETAIL = new HashSet<SM_DETAIL>();
            this.SM_HEADER = new HashSet<SM_HEADER>();
            this.SM_HEADER1 = new HashSet<SM_HEADER>();
            this.SO_DETAIL = new HashSet<SO_DETAIL>();
            this.SO_HEADER = new HashSet<SO_HEADER>();
            this.SO_HEADER1 = new HashSet<SO_HEADER>();
            this.SO_HEADER2 = new HashSet<SO_HEADER>();
            this.STOCKs = new HashSet<STOCK>();
            this.STOCK_RESERVATIONS = new HashSet<STOCK_RESERVATIONS>();
            this.STOCK_RESERVATIONS1 = new HashSet<STOCK_RESERVATIONS>();
            this.SYS_USERS1 = new HashSet<SYS_USERS>();
        }
    
        public decimal SYSUR_AUTO_KEY { get; set; }
        public string USER_NAME { get; set; }
        public string PASS_KEY { get; set; }
        public string CANNOT_MODIFY { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string DEPARTMENT { get; set; }
        public string ARCHIVED { get; set; }
        public string KILL_USER { get; set; }
        public string WO_FLAG { get; set; }
        public string REFRESH_DATA { get; set; }
        public string LOGGED_IN { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string FAX_NUMBER { get; set; }
        public string ATTENTION { get; set; }
        public string CONVERTED { get; set; }
        public string AUTH_CODE { get; set; }
        public string AUTH_FLAG { get; set; }
        public Nullable<decimal> POD_LIMIT { get; set; }
        public string USER_ID { get; set; }
        public Nullable<decimal> WOK_AUTO_KEY { get; set; }
        public Nullable<decimal> GEO_AUTO_KEY { get; set; }
        public Nullable<decimal> CQD_LIMIT { get; set; }
        public string CQ_AUTH_FLAG { get; set; }
        public Nullable<decimal> DPT_AUTO_KEY { get; set; }
        public string PWD { get; set; }
        public Nullable<decimal> CQD_MARGIN_LIMIT { get; set; }
        public Nullable<decimal> SOD_MARGIN_LIMIT { get; set; }
        public string SO_AUTH_FLAG { get; set; }
        public Nullable<decimal> PRL_AUTO_KEY { get; set; }
        public Nullable<decimal> PR_AUTH_LIMIT { get; set; }
        public string PR_SUPERVISOR { get; set; }
        public Nullable<decimal> PJD_AUTO_KEY { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string ILS_USER { get; set; }
        public string ILS_PWD { get; set; }
        public string EMAIL_SIGNATURE { get; set; }
        public Nullable<decimal> CQD_PROFIT_LIMIT { get; set; }
        public Nullable<decimal> SOD_PROFIT_LIMIT { get; set; }
        public Nullable<decimal> CQD_DOLLAR_LIMIT { get; set; }
        public Nullable<decimal> SOD_DOLLAR_LIMIT { get; set; }
        public string EB_USERID { get; set; }
        public string EB_PASSWORD { get; set; }
        public Nullable<decimal> WTL_AUTO_KEY { get; set; }
        public string MKT_USERID { get; set; }
        public string MKT_PASSWORD { get; set; }
        public string MO_FLAG { get; set; }
        public Nullable<decimal> SPN_AUTO_KEY { get; set; }
        public string ILS_CERTIFICATION { get; set; }
        public string ILS_TOKEN { get; set; }
        public string CAMP_USER { get; set; }
        public string CAMP_PWD { get; set; }
        public string SDF_SYSUR_001 { get; set; }
        public string SDF_SYSUR_002 { get; set; }
        public string SDF_SYSUR_003 { get; set; }
        public string SDF_SYSUR_004 { get; set; }
        public string SDF_SYSUR_005 { get; set; }
        public string SDF_SYSUR_006 { get; set; }
        public string SDF_SYSUR_007 { get; set; }
        public string SDF_SYSUR_008 { get; set; }
        public string SDF_SYSUR_009 { get; set; }
        public string SDF_SYSUR_010 { get; set; }
        public Nullable<System.DateTime> START_DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public Nullable<decimal> CMP_AUTO_KEY { get; set; }
        public string BIRTH_PLACE { get; set; }
        public Nullable<System.DateTime> BIRTH_DATE { get; set; }
        public string NATIONALITY { get; set; }
        public string HOME_COUNTRY { get; set; }
        public string NAA_REF { get; set; }
        public string LICENSE_NUMBER { get; set; }
        public string LICENSE_TYPE { get; set; }
        public Nullable<System.DateTime> LICENSE_ISSUED_DATE { get; set; }
        public Nullable<System.DateTime> LICENSE_VALID_DATE { get; set; }
        public string CERTIFYING_STAFF { get; set; }
        public Nullable<System.DateTime> CERTIF_ISSUED_DATE { get; set; }
        public Nullable<System.DateTime> CERTIF_VALID_DATE { get; set; }
        public string MOBILE_PHONE { get; set; }
        public string AUDIT_TRACK_FLAG { get; set; }
        public Nullable<decimal> SESSION_TIME_OUT { get; set; }
        public Nullable<System.DateTime> LAST_PWD_CHANGE { get; set; }
        public Nullable<decimal> LOGIN_ATTEMPTS { get; set; }
        public string USER_ROLE { get; set; }
        public Nullable<decimal> TAH_AUTO_KEY { get; set; }
        public string CONTRACTOR { get; set; }
        public string DOUBLE_TIME { get; set; }
        public Nullable<decimal> TAC_AUTO_KEY { get; set; }
        public Nullable<decimal> SYSUR_TA_SUPER { get; set; }
        public string OVER_TIME { get; set; }
        public string BATCH_ID { get; set; }
        public string RATE_CODE { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string SEPARATE_GLB { get; set; }
        public Nullable<decimal> VISIBILITY_FILTER { get; set; }
        public string GEO_FILTER { get; set; }
        public string AVTRAK_USER { get; set; }
        public string AVTRAK_PWD { get; set; }
        public Nullable<decimal> BURDEN_RATE { get; set; }
        public Nullable<decimal> FIXED_OVERHEAD { get; set; }
        public Nullable<decimal> VARIABLE_OVERHEAD { get; set; }
        public string ALLOW_MULTI_LOGIN { get; set; }
        public string RECORDED { get; set; }
        public Nullable<decimal> CONVERSION_ID { get; set; }
        public string FLIGHTDOCS_USER { get; set; }
        public string FLIGHTDOCS_PWD { get; set; }
        public string TL_AUTH { get; set; }
        public byte[] SIG_IMG { get; set; }
        public byte[] STAMP_IMG { get; set; }
        public Nullable<decimal> AGN_AUTO_KEY { get; set; }
        public string NETJETS_USER { get; set; }
        public string NETJETS_PWD { get; set; }
        public Nullable<decimal> GLD_WO_EMPL_CREDIT { get; set; }
        public string EXEMPT { get; set; }
        public string BUDGET_ADMIN { get; set; }
        public string DIRECT { get; set; }
        public Nullable<decimal> SICK { get; set; }
        public Nullable<decimal> VACATION { get; set; }
        public Nullable<decimal> COMP { get; set; }
        public Nullable<decimal> MILITARY { get; set; }
        public string SSN { get; set; }
        public string PAY_GROUP { get; set; }
        public Nullable<decimal> PERSONAL { get; set; }
        public string URL_LINK { get; set; }
        public Nullable<decimal> ACB_DEFAULT { get; set; }
        public Nullable<decimal> ACB_CURRENT { get; set; }
        public string ALT_USER_ID { get; set; }
        public Nullable<decimal> USER_EMAIL_PROTOCOL { get; set; }
        public string SMTP_EMAIL_ADDRESS { get; set; }
        public string SMTP_REQ_AUTH { get; set; }
        public string SMTP_USERNAME { get; set; }
        public string SMTP_PWD { get; set; }
        public string SMTP_REPLY_TO_ADDRESS { get; set; }
        public string SMTP_REPLY_TO_NAME { get; set; }
        public string SMTP_CC_ADDRESS { get; set; }
        public string SMTP_SERVER { get; set; }
        public string SMTP_USE_NONDEFAULT_PORT { get; set; }
        public Nullable<decimal> SMTP_PORT { get; set; }
        public Nullable<decimal> SMTP_EMAIL_TIMEOUT { get; set; }
        public string SMTP_USE_SECURE_CONNECTION { get; set; }
        public string MAPI_USER_PROFILE { get; set; }
        public string MAPI_PWD { get; set; }
        public string MAPI_USE_CLIENT_FORM { get; set; }
        public string MAPI_USE_HTML_FOR_BODY { get; set; }
        public string MAPI_USE_SHARED_SESSION { get; set; }
        public string MAPI_FORCE_ONLINE { get; set; }
        public string MAPI_DEFAULT_FOLDER { get; set; }
        public string EMAIL_CONFIG_SIGNATURE { get; set; }
        public string CAN_SIGN_OFF1 { get; set; }
        public string CAN_SIGN_OFF2 { get; set; }
        public string AD_LDAP_PATH { get; set; }
        public string AD_LDAP_FRIENDLY_NAME { get; set; }
        public string MAPI_REPLY_TO_ADDRESS { get; set; }
        public Nullable<decimal> SYSCM_AUTO_KEY { get; set; }
    
        public virtual AGENT AGENT { get; set; }
        public virtual ICollection<AP_ACCOUNT> AP_ACCOUNT { get; set; }
        public virtual ICollection<AP_DETAIL> AP_DETAIL { get; set; }
        public virtual ICollection<AR_ACCOUNT> AR_ACCOUNT { get; set; }
        public virtual ICollection<AR_DETAIL> AR_DETAIL { get; set; }
        public virtual COMPANy COMPANy { get; set; }
        public virtual ICollection<COMPANy> COMPANIES { get; set; }
        public virtual ICollection<COMPANy> COMPANIES1 { get; set; }
        public virtual ICollection<COMPANy> COMPANIES2 { get; set; }
        public virtual ICollection<CQ_DETAIL> CQ_DETAIL { get; set; }
        public virtual ICollection<CQ_HEADER> CQ_HEADER { get; set; }
        public virtual ICollection<CQ_HEADER> CQ_HEADER1 { get; set; }
        public virtual ICollection<CURRENCY> CURRENCies { get; set; }
        public virtual DEPARTMENT DEPARTMENT1 { get; set; }
        public virtual ICollection<INVC_DETAIL> INVC_DETAIL { get; set; }
        public virtual ICollection<INVC_HEADER> INVC_HEADER { get; set; }
        public virtual ICollection<INVC_HEADER> INVC_HEADER1 { get; set; }
        public virtual ICollection<PI_HEADER> PI_HEADER { get; set; }
        public virtual ICollection<PO_DETAIL> PO_DETAIL { get; set; }
        public virtual ICollection<PO_HEADER> PO_HEADER { get; set; }
        public virtual ICollection<PO_HEADER> PO_HEADER1 { get; set; }
        public virtual ICollection<PO_HEADER> PO_HEADER2 { get; set; }
        public virtual ICollection<RC_SERIAL> RC_SERIAL { get; set; }
        public virtual ICollection<RO_DETAIL> RO_DETAIL { get; set; }
        public virtual ICollection<RO_HEADER> RO_HEADER { get; set; }
        public virtual ICollection<RO_HEADER> RO_HEADER1 { get; set; }
        public virtual ICollection<RO_HEADER> RO_HEADER2 { get; set; }
        public virtual ICollection<RO_PRE_COSTING_CHARGES> RO_PRE_COSTING_CHARGES { get; set; }
        public virtual ICollection<SM_DETAIL> SM_DETAIL { get; set; }
        public virtual ICollection<SM_HEADER> SM_HEADER { get; set; }
        public virtual ICollection<SM_HEADER> SM_HEADER1 { get; set; }
        public virtual ICollection<SO_DETAIL> SO_DETAIL { get; set; }
        public virtual ICollection<SO_HEADER> SO_HEADER { get; set; }
        public virtual ICollection<SO_HEADER> SO_HEADER1 { get; set; }
        public virtual ICollection<SO_HEADER> SO_HEADER2 { get; set; }
        public virtual ICollection<STOCK> STOCKs { get; set; }
        public virtual ICollection<STOCK_RESERVATIONS> STOCK_RESERVATIONS { get; set; }
        public virtual ICollection<STOCK_RESERVATIONS> STOCK_RESERVATIONS1 { get; set; }
        public virtual ICollection<SYS_USERS> SYS_USERS1 { get; set; }
        public virtual SYS_USERS SYS_USERS2 { get; set; }
    }
}