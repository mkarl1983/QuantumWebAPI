using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumWebAPI.Models
{
    public class RepairOrder
    {

        public string RONumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComapanyName { get; set; }
        public string PartNumber { get; set; }
        public string Status { get; set; }
        public string SONumber { get; set; }
        public int DaysAging
        {
            get


            {

                var days = 0;
                switch (Status)
                {
                    case "A/W CUSTOMER APPROVAL":
                        if (!string.IsNullOrEmpty(SONumber) && UDF002.HasValue)
                        {
                            days = (int)(DateTime.Now - UDF002.Value).TotalDays;
                            
                        }
                        else
                        {
                            days = 0;
                        }
                        break;
                    case "DO NOT CHASE":
                        if (UDF003.HasValue)
                            days = (int)(DateTime.Now - UDF003.Value).TotalDays;
                        else
                            days = 0;
                        break;

                    case "APPROVED/OVERDUE":
                        if (UDF003.HasValue)
                            days = (int)(DateTime.Now - UDF003.Value).TotalDays;
                        else
                            days = 0;
                        break;

                    default :
                        days = (int)(DateTime.Now - EntryDate).TotalDays;
                        break;
                }
               // return (int)(DateTime.Now - EntryDate).TotalDays;

                return days;
            }
        }

        public DateTime? UDF002 { get; set; }

        public DateTime? UDF003 { get; set; }

        public string ShortComapanyName {

            //get
            //{
            //    return string.IsNullOrEmpty(ComapanyName) ? "" : ComapanyName.Substring(0, 10);
            //}
            get
            {
                return string.IsNullOrEmpty(ComapanyName) ? "" : ComapanyName.Length > 8 ? ComapanyName.Substring(0, 8) : ComapanyName;
            }
        
        }

    }
}