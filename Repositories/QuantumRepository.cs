
using System;
using System.Collections.Generic;
using System.Linq;
using QuantumWebAPI.Models;
using QuntumDB.QuantumModel;


namespace QuantumWebAPI.Repositories
{
    /// <summary>
    /// Implementation of IQuantumRepository for Oracle DB
    /// </summary>
    public class QuantumRepository : IQuantumRepository
    {

        const string CLASSID = "QuantumRepository";

        #region Shipping 

        /// <summary>
        /// GetShippingFeeds
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shipping> GetShippingFeeds()
        {
            IEnumerable<Shipping> resultData;
            const string MethodName = "GetShippingFeeds()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from f in dc.SM_DETAIL
                                where (f.SM_HEADER.SM_STATUS.DESCRIPTION != "SHIPPED")
                                orderby f.SM_HEADER.SM_NUMBER
                                select new Shipping
                                {
                                    ShipNumber = f.SM_HEADER.SM_NUMBER,
                                    Status = f.SM_HEADER.SM_STATUS.STATUS_CODE,
                                    Date = f.SM_HEADER.ENTRY_DATE.Value,
                                    SO = f.SM_HEADER.SO_HEADER.SO_NUMBER,
                                    PO = f.SM_HEADER.PO_HEADER.PO_NUMBER,
                                    RO = f.SM_HEADER.RO_HEADER.RO_NUMBER,
                                    Priority = (f.SM_HEADER.SO_HEADER != null) ? f.SM_HEADER.SO_HEADER.PRIORITY.Value :
                                    (f.SM_HEADER.PO_HEADER != null) ? f.SM_HEADER.PO_HEADER.PRIORITY.Value :
                                    (f.SM_HEADER.RO_HEADER != null) ? f.SM_HEADER.RO_HEADER.SHIP_PRIORITY.Value : 0,

                                    PartNumber = f.PARTS_MASTER.PN,
                                    IsHazmat = f.PARTS_MASTER.HAZARD_MATERIAL,

                                    Customer = f.SM_HEADER.COMPANy1.COMPANY_NAME
                                };

                    resultData = query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// GetWarehouseShipmentsAndRepairsOrders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shipping> GetWarehouseShipmentsAndRepairsOrders()
        {
            IEnumerable<Shipping> resultData;
            const string MethodName = "GetWarehouseShipmentsAndRepairsOrders()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from f in dc.SM_HEADER
                                where (f.SM_STATUS.STATUS_CODE != "SHIPPED")
                                orderby f.SM_NUMBER descending

                                select new Shipping
                                {
                                    ShipNumber = f.SM_NUMBER,
                                    Status = f.SM_STATUS.STATUS_CODE,
                                    Date = f.DATE_CREATED.Value,
                                    SO = f.SO_HEADER.SO_NUMBER,
                                    PO = f.PO_HEADER.PO_NUMBER,
                                    RO = f.RO_HEADER.RO_NUMBER,
                                    Priority = (f.SO_HEADER != null) ? f.SHIP_PRIORITY.HasValue ? f.SHIP_PRIORITY.Value : 4
                                 : (f.PO_HEADER != null) ? f.PO_HEADER.PRIORITY.HasValue ? f.PO_HEADER.PRIORITY.Value : 4
                                 : (f.RO_HEADER != null) ? f.RO_HEADER.SHIP_PRIORITY.HasValue ? f.RO_HEADER.SHIP_PRIORITY.Value : 4
                                 : 4,
                                    // PartNumber = f.PARTS_MASTER.PN,
                                    IsHazmat = string.IsNullOrEmpty(f.HAZMAT_NOTES) ? "F" : "T",

                                    Customer = f.COMPANy1.COMPANY_NAME,

                                    SalesPerson = (f.SO_HEADER != null) ? f.SO_HEADER.SYS_USERS1.USER_NAME : (f.PO_HEADER != null) ? f.PO_HEADER.SYS_USERS.USER_NAME : (f.RO_HEADER != null) ? f.RO_HEADER.SYS_USERS.USER_NAME : ""
                                };
                    resultData = query.ToList();

                }

                // process shipping status for UI
                if (resultData.Any())
                {
                    foreach (var shipping in resultData)
                    {
                        //Needs Pick: 
                        //NEEDS PICK

                        //In Process:
                        //ALL STARTED#  statuses
                        //Docs
                        //DG Note
                        //Repair Doc
                        //PN Labels
                        //Core Retrn

                        //A/W Collection:
                        //A/W Collection
                        //Lockbox 1
                        //Lockbox 2
                        //Lockbox 3
                        //Lockbox 4

                        if (shipping.Status.ToUpper().StartsWith("STARTED")) shipping.Status = "IN PROCESS";
                        if (shipping.Status.ToUpper().StartsWith("LOCKBOX")) shipping.Status = "A/W COLLECTION";
                        switch (shipping.Status.ToUpper())
                        {
                            case "DOCS":
                            case "DG NOTE":
                            case "REPAIR DOC":
                            case "PN LABELS":
                            case "CORE RETRN":
                                shipping.Status = "IN PROCESS";
                                break;
                        }
                        switch (shipping.Priority)
                        {
                            case 0: shipping.PriorityType = "ROUTINE"; break;
                            case 1: shipping.PriorityType = "CRITICAL"; break;
                            case 2: shipping.PriorityType = "AOG"; break;
                            default: shipping.PriorityType = "DEFAULT"; break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        #endregion

        #region Sales 
        /// <summary>
        /// GetSalesOrdersFeed for Today
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesOrder> GetSalesOrdersFeed()
        {
            IEnumerable<SalesOrder> resultData;
            const string MethodName = "GetSalesOrdersFeed()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    DateTime TodaysDate = DateTime.Now.Date;
                    var query = from orderdetail in dc.SO_DETAIL
                                where orderdetail.SO_HEADER.DATE_CREATED.Value >= TodaysDate && orderdetail.CUSTOMER_PRICE.HasValue && orderdetail.QTY_ORDERED.HasValue
                                      && (orderdetail.ROUTE_CODE == "S" || orderdetail.ROUTE_CODE == "E")
                                orderby orderdetail.SO_HEADER.DATE_CREATED.Value descending
                                select new SalesOrder
                                {
                                    SalesNumber = orderdetail.SO_HEADER.SO_NUMBER,
                                    Date = orderdetail.SO_HEADER.DATE_CREATED.Value,
                                    Customer = orderdetail.SO_HEADER.COMPANy.COMPANY_NAME,
                                    Description = orderdetail.PARTS_MASTER.DESCRIPTION,
                                    PartNumber = orderdetail.PARTS_MASTER.PN,
                                    Type = orderdetail.ROUTE_DESC,
                                    UnitPrice = orderdetail.CUSTOMER_PRICE.Value,
                                    Currency = orderdetail.SO_HEADER.CURRENCY.CURRENCY_CODE,
                                    Employee = orderdetail.SYS_USERS.EMPLOYEE_CODE,
                                    TotalAmount = (orderdetail.QTY_ORDERED.Value * orderdetail.CUSTOMER_PRICE.Value),
                                    Quantity = orderdetail.QTY_ORDERED.Value,
                                    Serialized = orderdetail.PARTS_MASTER.SERIALIZED
                                };
                    var result = query.ToList().Where(o => !o.PartNumber.StartsWith("CORE REPAIR")).Select(o => o).ToList();

                    var SerializedSalesOrders = result.Where(o => o.Serialized == "T").OrderByDescending(o => o.Date.TimeOfDay).ToList();

                    var UnSerializedSalesOrders = (
                        from orderitem in result.Where(o => o.Serialized == "F").OrderByDescending(o => o.Date.TimeOfDay)
                        group orderitem by
                            orderitem.SalesNumber
                         into gcs
                        select new SalesOrder
                        {
                            SalesNumber = gcs.Key,
                            Date = gcs.Select(o => o.Date).Distinct().FirstOrDefault(),
                            Employee = gcs.Select(o => o.Employee).Distinct().FirstOrDefault(),
                            Type = gcs.Select(o => o.Type).Distinct().FirstOrDefault(),
                            Currency = gcs.Select(o => o.Currency).Distinct().FirstOrDefault(),
                            Customer = gcs.Select(o => o.Customer).Distinct().FirstOrDefault(),
                            Serialized = gcs.Select(o => o.Serialized).Distinct().FirstOrDefault(),
                            TotalAmount = gcs.Sum(o => o.TotalAmount)
                        }
                        ).ToList();


                    var mergedList = new List<SalesOrder>();
                    mergedList.AddRange(SerializedSalesOrders);
                    mergedList.AddRange(UnSerializedSalesOrders);
                    resultData = mergedList.OrderByDescending(o => o.Date.TimeOfDay);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// Get Sales Count by start date and end date where start date uses only date component and enddate uses date and time component.
        /// for example todays sales count start and end date is today but start and end time is different
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public int GetSalesOrdersCount(DateTime StartDate, DateTime EndDate)
        {
            int resultData;
            const string MethodName = "GetSalesCount()";
            try
            {
                  DateTime _startDate = StartDate.Date;
                  DateTime _endDate = EndDate;

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from salesOrder in dc.SO_HEADER
                                where (salesOrder.DATE_CREATED.Value >= _startDate && salesOrder.DATE_CREATED.Value <= _endDate)
                                select salesOrder;
                    var salesytdCount = query.Count();
                    if (salesytdCount > 0)
                        resultData = salesytdCount;
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesTodayTotals()
        {
            decimal resultData;
            const string MethodName = "GetSalesTodayTotals()";
            try
            {
                DateTime StartDate = DateTime.Now.Date;
                DateTime EndDate = DateTime.Now;

                resultData = GetSalesTotalsByStartEndDate(StartDate, EndDate);

                //using (QuantumEntities dc = new QuantumEntities())
                //{
                //    var query = from orderdetail in dc.SO_DETAIL
                //                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= StartDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= EndDate)
                //                select new { SalesAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0)) };

                //    var salesytdtotal = query.Sum(o => o.SalesAmount);
                //    if (salesytdtotal > 0)
                //        resultData = Math.Round(salesytdtotal, 0);
                //    else resultData = 0;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesMTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetSalesMTDTotals()";
            try
            {
                DateTime StartDate = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);
                resultData = GetSalesTotalsByStartEndDate(StartDate, EndDate);
                //using (QuantumEntities dc = new QuantumEntities())
                //{
                //    var query = from orderdetail in dc.SO_DETAIL
                //                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= StartDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= EndDate)
                //                select new{SalesAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0))};

                //    var salesytdtotal = query.Sum(o => o.SalesAmount);
                //    if (salesytdtotal > 0)
                //        resultData = Math.Round(salesytdtotal, 0);
                //    else resultData = 0;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesYTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetSalesYTDTotals()";
            try
            {
                DateTime StartDate = YTDDate(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);
                resultData = GetSalesTotalsByStartEndDate(StartDate, EndDate);
                //using (QuantumEntities dc = new QuantumEntities())
                //{
                //    var query = from orderdetail in dc.SO_DETAIL
                //                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= StartDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= EndDate)
                //                select new
                //                {
                //                    SalesAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0))
                //                };
                //    var salesytdtotal = query.Sum(o => o.SalesAmount);
                //    if (salesytdtotal > 0)
                //        resultData = Math.Round(salesytdtotal, 0);
                //    else resultData = 0;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesQTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetSalesQTDTotals";
            try
            {
                DateTime StartDate = GetQuarterStartingDate(DateTime.Now);
                DateTime EndDate = GetQuarterEndDate(DateTime.Now);
                resultData = GetSalesTotalsByStartEndDate(StartDate, EndDate);
                //using (QuantumEntities dc = new QuantumEntities())
                //{
                //    var query = from orderdetail in dc.SO_DETAIL
                //                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= StartDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= EndDate)
                //                select new
                //                {
                //                    SalesAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0))
                //                };
                //    var salesytdtotal = query.Sum(o => o.SalesAmount);
                //    if (salesytdtotal > 0)
                //        resultData = Math.Round(salesytdtotal, 0);
                //    else resultData = 0;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesLTMTotals()
        {
            decimal resultData;
            const string MethodName = "GetSalesLTMTotals";
            try
            {
                DateTime StartDate = Last12MonthsDate(DateTime.Now);
                DateTime EndDate = DateTime.Now;
                resultData = GetSalesTotalsByStartEndDate(StartDate, EndDate);
                //using (QuantumEntities dc = new QuantumEntities())
                //{
                //    var query = from orderdetail in dc.SO_DETAIL
                //                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= StartDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= EndDate)
                //                select new
                //                {
                //                    SalesAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0))

                //                };
                //    var salesytdtotal = query.Sum(o => o.SalesAmount);
                //    if (salesytdtotal > 0)
                //        resultData = Math.Round(salesytdtotal, 0);
                //    else resultData = 0;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// Get Sales Totals By Start and End Date.
        /// if no start or end date is given it will send result for todays sales totals
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public decimal GetSalesTotalsByStartEndDate(DateTime? StartDate, DateTime? EndDate)
        {
            decimal resultData;
            const string MethodName = "GetSalesTotalsByStartEndDate";
            try
            {
                DateTime _startDate =   StartDate.HasValue ? new DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day)  : new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime _endDate = EndDate.HasValue ? new DateTime(EndDate.Value.Year, EndDate.Value.Month, EndDate.Value.Day,23,59,00) : DateTime.Now;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from orderdetail in dc.SO_DETAIL
                                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= _startDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= _endDate)
                                select new
                                {
                                    SalesAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0))

                                };
                    var salesytdtotal = query.Sum(o => o.SalesAmount);
                    if (salesytdtotal > 0)
                        resultData = Math.Round(salesytdtotal, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllRatioTotals GetSaleOrderToQuoteRatios()
        {
            AllRatioTotals resultData;
            const string MethodName = "GetSaleOrderToQuoteRatios()";
            try
            {
                DateTime TodaysDate = DateTime.Now;
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                int TodaySales = GetSalesOrdersCount(TodaysDate.Date, TodaysDate);
                int MTDSales = GetSalesOrdersCount(FirstDayOfMonth(TodaysDate), TodaysDate);
                int YTDSales = GetSalesOrdersCount(YTDDate(TodaysDate), TodaysDate);
                int QTDSales = GetSalesOrdersCount(GetQuarterStartingDate(TodaysDate), GetQuarterEndDate(TodaysDate));
                int LTMSales = GetSalesOrdersCount(Last12MonthsDate(TodaysDate), TodaysDate);

                int TodayQuotes = GetQuotesCount(TodaysDate.Date, TodaysDate);
                int MTDQuotes = GetQuotesCount(FirstDayOfMonth(TodaysDate), TodaysDate);
                int YTDQuotes = GetQuotesCount(YTDDate(TodaysDate), TodaysDate);
                int QTDQuotes = GetQuotesCount(GetQuarterStartingDate(TodaysDate), GetQuarterEndDate(TodaysDate));
                int LTMQuotes = GetQuotesCount(Last12MonthsDate(TodaysDate), TodaysDate);

                double TodayOTQRatio = (TodaySales > 0 && TodayQuotes > 0) ? Math.Round((((double)TodaySales / TodayQuotes) * 100), 2) : (double)0;
                double MTDOTQRatio = (MTDSales > 0 && MTDQuotes > 0) ? Math.Round((((double)MTDSales / MTDQuotes) * 100), 2) : (double)0;
                double YTDOTQRatio = (YTDSales > 0 && YTDQuotes > 0) ? Math.Round((((double)YTDSales / YTDQuotes) * 100), 2) : (double)0;
                double QTDOTQRatio = (QTDSales > 0 && QTDQuotes > 0) ? Math.Round((((double)QTDSales / QTDQuotes) * 100), 2) : (double)0;
                double LTMOTQRatio = (LTMSales > 0 && LTMQuotes > 0) ? Math.Round((((double)LTMSales / LTMQuotes) * 100), 2) : (double)0;

                resultData = new AllRatioTotals() { TodayTotals = TodayOTQRatio, MTDTotals = MTDOTQRatio, YTDTotals = YTDOTQRatio, QTDTotals = QTDOTQRatio, LTMTotals = LTMOTQRatio };
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetSalesOrderTotals()
        {
            AllTotals resultData;
            const string MethodName = "GetSalesOrderTotals()";
            try
            {
                //DateTime TodaysDate = DateTime.Now;
                //DateTime EndDate = LastDayOfMonth(DateTime.Now);

                decimal TodaySales = GetSalesTodayTotals();
                decimal MTDSales = GetSalesMTDTotals();
                decimal YTDSales = GetSalesYTDTotals();
                decimal QTDSales = GetSalesQTDTotals();
                decimal LTMSales = GetSalesLTMTotals();

                resultData = new AllTotals() { TodayTotals = TodaySales, MTDTotals = MTDSales, YTDTotals = YTDSales, QTDTotals = QTDSales, LTMTotals = LTMSales };
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        #endregion

        #region Quotes 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public int GetQuotesCount(DateTime StartDate, DateTime EndDate)
        {
            int resultData;
            const string MethodName = "GetQuotesCount()";
            try
            {
                // DateTime StartDate = Last12MonthsDate(DateTime.Now);
                // DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from quoteHeader in dc.CQ_HEADER
                                where (quoteHeader.DATE_CREATED.Value >= StartDate && quoteHeader.DATE_CREATED.Value <= EndDate)
                                select quoteHeader;
                    // no quotes filter need to apply  


                    int quoteytdCount = query.Count();
                    if (quoteytdCount > 0)
                        resultData = quoteytdCount;
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// GetQuoteFeeds
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Quote> GetQuoteFeeds()
        {
            IEnumerable<Quote> resultData;
            const string MethodName = "GetQuoteFeeds()";
            try
            {
                DateTime TodaysDate = DateTime.Now;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from quotedetail in dc.CQ_DETAIL
                                where quotedetail.CQ_HEADER.DATE_CREATED.Value.Day == TodaysDate.Day &&
                                      quotedetail.CQ_HEADER.DATE_CREATED.Value.Month == TodaysDate.Month &&
                                      quotedetail.CQ_HEADER.DATE_CREATED.Value.Year == TodaysDate.Year
                                orderby quotedetail.CQ_HEADER.DATE_CREATED.Value descending
                                select new Quote
                                {
                                    QuoteNumber = quotedetail.CQ_HEADER.CQ_NUMBER,
                                    PartNumber = quotedetail.PARTS_MASTER.PN,
                                    Description = quotedetail.PARTS_MASTER.DESCRIPTION,
                                    Date = quotedetail.CQ_HEADER.DATE_CREATED.Value,
                                    Type = quotedetail.ROUTE_DESC,
                                    Currency = quotedetail.CQ_HEADER.CURRENCY.CURRENCY_CODE,
                                    UnitPrice = quotedetail.CUSTOMER_PRICE.Value,
                                    Customer = quotedetail.CQ_HEADER.BILL_NAME,
                                    Employee = quotedetail.SYS_USERS.EMPLOYEE_CODE,
                                    Quantity = quotedetail.QTY_QUOTED.Value,
                                    TotalAmount = (quotedetail.CUSTOMER_PRICE.Value * quotedetail.QTY_QUOTED.Value)
                                };

                    resultData = query.OrderByDescending(q => q.Date).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public decimal GetYTDQuotesTotals(DateTime StartDate, DateTime EndDate)
        {
            decimal resultData;
            const string MethodName = "GetYTDQuotesTotals()";
            try
            {
                //  DateTime StartDate = Last12MonthsDate(DateTime.Now);
                //  DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from quotedetail in dc.CQ_DETAIL
                                where (quotedetail.CQ_HEADER.DATE_CREATED.Value >= StartDate && quotedetail.CQ_HEADER.DATE_CREATED.Value <= EndDate)
                                select new
                                {
                                    QuoteAmount = (quotedetail.CUSTOMER_PRICE.Value * quotedetail.QTY_QUOTED.Value)
                                };


                    var quoteytdtotal = query.Sum(o => o.QuoteAmount);
                    if (quoteytdtotal > 0)
                        resultData = Math.Round(quoteytdtotal, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }



        #endregion

        #region PartNumber Stats

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PartNumberHit> GetPartNumberTodayHits()
        {
            IEnumerable<PartNumberHit> resultData;
            const string MethodName = "GetPartNumberTodayHits()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = (from quotedetail in dc.CQ_DETAIL
                                 where quotedetail.CQ_HEADER.DATE_CREATED.Value.Day == DateTime.Now.Day &&
                                       quotedetail.CQ_HEADER.DATE_CREATED.Value.Month == DateTime.Now.Month &&
                                       quotedetail.CQ_HEADER.DATE_CREATED.Value.Year == DateTime.Now.Year

                                         && (quotedetail.ROUTE_DESC != "Misc" && quotedetail.ROUTE_DESC != "Freight" && quotedetail.ROUTE_DESC != "Labor")
                                         && quotedetail.PARTS_MASTER.PN != "DOT31FP COMPLIANT BOX"
                                 orderby quotedetail.CQ_HEADER.DATE_CREATED.Value descending
                                 group quotedetail by quotedetail.PARTS_MASTER.PN into grp
                                 where grp.Count() > 2
                                 select new PartNumberHit
                                 {
                                     PartNumber = grp.Key,
                                     Hits = grp.Count()
                                 }).OrderByDescending(y => y.Hits);

                    resultData = query.Take(5).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodRecevied> GetGRNFeeds()
        {
            IEnumerable<GoodRecevied> resultData;
            const string MethodName = "GetGRNFeeds()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from rcd in dc.RC_DETAIL
                                where rcd.RC_HEADER.OPEN_FLAG == "T"
                                select new GoodRecevied
                                {
                                    GRN = rcd.RC_HEADER.RC_NUMBER,
                                    Description = rcd.PARTS_MASTER.DESCRIPTION,
                                    Date = rcd.RC_HEADER.ENTRY_DATE.Value,
                                    OrderType = rcd.RC_HEADER.ORDER_TYPE1,
                                    OrderNumber = rcd.RC_HEADER.ORDER_NUMBER1,
                                    SerialNumber = (rcd.SERIALIZED == "T") ? rcd.RC_SERIAL.FirstOrDefault().SERIAL_NUMBER : " ",
                                    PartNumber = rcd.PARTS_MASTER.PN,
                                    Qty = rcd.QTY.Value,
                                    Customer = rcd.RC_HEADER.COMPANY_NAME

                                };
                    ////////////////////////////////////////////////////////////////////////////////////////////////
                    resultData = query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PartNumberHit> GetPartNumber30DayHits()
        {
            IEnumerable<PartNumberHit> resultData;
            const string MethodName = "GetPartNumber30DayHits()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    DateTime StartDate = DateTime.Now.AddDays(-30);
                    DateTime EndDate = DateTime.Now;
                    var query = (from quotedetail in dc.CQ_DETAIL
                                 where
                                 (quotedetail.CQ_HEADER.DATE_CREATED.Value >= StartDate && quotedetail.CQ_HEADER.DATE_CREATED.Value <= EndDate)
                                  && (quotedetail.ROUTE_DESC != "Misc" && quotedetail.ROUTE_DESC != "Freight" && quotedetail.ROUTE_DESC != "Labor")
                                  && quotedetail.PARTS_MASTER.PN != "DOT31FP COMPLIANT BOX"
                                 orderby quotedetail.CQ_HEADER.DATE_CREATED.Value descending
                                 group quotedetail by quotedetail.PARTS_MASTER.PN into grp
                                 where grp.Count() > 2
                                 select new PartNumberHit
                                 {
                                     PartNumber = grp.Key,
                                     Hits = grp.Count()
                                 }).OrderByDescending(y => y.Hits);

                    resultData = query.Take(20).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        #endregion

        #region Employee Totals

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeQuotes> GetEmployeeTodayQuotes()
        {
            IEnumerable<EmployeeQuotes> resultData;
            const string MethodName = "GetEmployeeTodayQuotes()";
            try
            {
                DateTime TodaysDate = DateTime.Now;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from quotedetail in dc.CQ_DETAIL
                                where (
                                       quotedetail.CQ_HEADER.DATE_CREATED.Value.Day == TodaysDate.Day &&
                                      quotedetail.CQ_HEADER.DATE_CREATED.Value.Month == TodaysDate.Month &&
                                      quotedetail.CQ_HEADER.DATE_CREATED.Value.Year == TodaysDate.Year)
                                select new Quote
                                {
                                    QuoteNumber = quotedetail.CQ_HEADER.CQ_NUMBER,
                                    PartNumber = quotedetail.PARTS_MASTER.PN,
                                    Description = quotedetail.PARTS_MASTER.DESCRIPTION,
                                    Date = quotedetail.CQ_HEADER.DATE_CREATED.Value,
                                    Type = quotedetail.ROUTE_DESC,
                                    Currency = quotedetail.CQ_HEADER.CURRENCY.CURRENCY_CODE,
                                    UnitPrice = quotedetail.CUSTOMER_PRICE.Value,
                                    Customer = quotedetail.CQ_HEADER.BILL_NAME,
                                    Employee = quotedetail.SYS_USERS.EMPLOYEE_CODE,
                                    Quantity = quotedetail.QTY_QUOTED.Value,
                                    TotalAmount = (quotedetail.CUSTOMER_PRICE.Value * quotedetail.QTY_QUOTED.Value)
                                };

                    var temp = from d in query.ToList()
                               group d by d.Employee into grp
                               select new EmployeeQuotes
                               {
                                   Employeee = grp.Key,
                                   QuotesCount = grp.Select(o => o.QuoteNumber).Distinct().Count(),
                                   TotalQuotesUnitPrice = grp.Sum(o => o.TotalAmount)
                               };

                    resultData = temp.OrderByDescending(o => o.QuotesCount).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeQuotes> GetEmployeeMTDQuotes()
        {
            IEnumerable<EmployeeQuotes> resultData;
            const string MethodName = "GetEmployeeMTDQuotes()";
            try
            {
                DateTime StartDate = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from quotedetail in dc.CQ_DETAIL
                                where (quotedetail.CQ_HEADER.DATE_CREATED.Value >= StartDate && quotedetail.CQ_HEADER.DATE_CREATED.Value <= EndDate)
                                select new Quote
                                {
                                    QuoteNumber = quotedetail.CQ_HEADER.CQ_NUMBER,
                                    PartNumber = quotedetail.PARTS_MASTER.PN,
                                    Description = quotedetail.PARTS_MASTER.DESCRIPTION,
                                    Date = quotedetail.CQ_HEADER.DATE_CREATED.Value,
                                    Type = quotedetail.ROUTE_DESC,
                                    Currency = quotedetail.CQ_HEADER.CURRENCY.CURRENCY_CODE,
                                    UnitPrice = quotedetail.CUSTOMER_PRICE.Value,
                                    Customer = quotedetail.CQ_HEADER.BILL_NAME,
                                    Employee = quotedetail.SYS_USERS.EMPLOYEE_CODE,
                                    Quantity = quotedetail.QTY_QUOTED.Value,
                                    TotalAmount = (quotedetail.CUSTOMER_PRICE.Value * quotedetail.QTY_QUOTED.Value)
                                };

                    var temp = from d in query.ToList()
                               group d by d.Employee into grp
                               select new EmployeeQuotes
                               {
                                   Employeee = grp.Key,
                                   QuotesCount = grp.Select(o => o.QuoteNumber).Distinct().Count(),
                                   TotalQuotesUnitPrice = grp.Sum(o => o.TotalAmount)
                               };

                    resultData = temp.OrderByDescending(o => o.QuotesCount).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSales> GetEmployeeTodaySalesOrders()
        {
            IEnumerable<EmployeeSales> resultData;
            const string MethodName = "GetTotalEmployeeSales()";
            try
            {
                DateTime TodaysDate = DateTime.Now.Date;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from orderdetail in dc.SO_DETAIL
                                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= TodaysDate)
                                select new SalesOrder
                                {
                                    SalesNumber = orderdetail.SO_HEADER.SO_NUMBER,
                                    Date = orderdetail.SO_HEADER.DATE_CREATED.Value,
                                    Customer = orderdetail.SO_HEADER.COMPANy.COMPANY_NAME,
                                    Description = orderdetail.PARTS_MASTER.DESCRIPTION,
                                    PartNumber = orderdetail.PARTS_MASTER.PN,
                                    Type = orderdetail.ROUTE_DESC,
                                    UnitPrice = orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0,
                                    Currency = orderdetail.SO_HEADER.CURRENCY.CURRENCY_CODE,
                                    Employee = orderdetail.SO_HEADER.SYS_USERS1.EMPLOYEE_CODE,
                                    TotalAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0)),
                                    Quantity = orderdetail.QTY_ORDERED.Value
                                };

                    var temp = from d in query.ToList()
                               group d by d.Employee into grp
                               select new EmployeeSales
                               {
                                   Employeee = grp.Key,
                                   SalesCount = grp.Select(o => o.SalesNumber).Distinct().Count(),
                                   TotalSalesUnitPrice = grp.Sum(o => o.TotalAmount)
                               };

                    resultData = temp.OrderByDescending(o => o.TotalSalesUnitPrice).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSales> GetEmployeeMTDSalesOrders()
        {
            IEnumerable<EmployeeSales> resultData;
            const string MethodName = "GetEmployeeMTDSalesOrders()";
            try
            {
                DateTime StartDate = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from orderdetail in dc.SO_DETAIL
                                where (orderdetail.SO_HEADER.DATE_CREATED.Value >= StartDate && orderdetail.SO_HEADER.DATE_CREATED.Value <= EndDate)
                                select new SalesOrder
                                {
                                    SalesNumber = orderdetail.SO_HEADER.SO_NUMBER,
                                    Date = orderdetail.SO_HEADER.DATE_CREATED.Value,
                                    Customer = orderdetail.SO_HEADER.COMPANy.COMPANY_NAME,
                                    Description = orderdetail.PARTS_MASTER.DESCRIPTION,
                                    PartNumber = orderdetail.PARTS_MASTER.PN,
                                    Type = orderdetail.ROUTE_DESC,
                                    UnitPrice = orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0,
                                    Currency = orderdetail.SO_HEADER.CURRENCY.CURRENCY_CODE,
                                    Employee = orderdetail.SO_HEADER.SYS_USERS1.EMPLOYEE_CODE,
                                    TotalAmount = (orderdetail.QTY_ORDERED.Value * (orderdetail.CUSTOMER_PRICE.HasValue ? orderdetail.CUSTOMER_PRICE.Value : 0)),
                                    Quantity = orderdetail.QTY_ORDERED.Value
                                };

                    var temp = from d in query.ToList()
                               group d by d.Employee into grp
                               select new EmployeeSales
                               {
                                   Employeee = grp.Key,
                                   SalesCount = grp.Select(o => o.SalesNumber).Distinct().Count(),
                                   TotalSalesUnitPrice = grp.Sum(o => o.TotalAmount)
                               };

                    resultData = temp.OrderByDescending(o => o.TotalSalesUnitPrice).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        #endregion

        #region  Invoice Order Totals

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceTodayTotals()
        {
            decimal resultData;
            const string MethodName = "GetInvoiceTodayTotals()";
            try
            {
                DateTime TodayDate = DateTime.Now;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from invoiceheader in dc.INVC_HEADER
                                where (
                                (
                                    invoiceheader.INVOICE_DATE.Day == TodayDate.Day
                                   && invoiceheader.INVOICE_DATE.Month == TodayDate.Month
                                   && invoiceheader.INVOICE_DATE.Year == TodayDate.Year
                                )
                                && invoiceheader.POST_STATUS == 3
                                && (invoiceheader.INVC_TYPE == "I" || invoiceheader.INVC_TYPE == "M"))
                                select new
                                {
                                    invoiceheader.FOREIGN_AMOUNT
                                };

                    var invoicemtdtotal = query.Sum(o => o.FOREIGN_AMOUNT);
                    if (invoicemtdtotal.HasValue)
                        resultData = Math.Round(invoicemtdtotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceMTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetInvoiceMTDTotals()";
            try
            {
                DateTime StartDate = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from invoiceheader in dc.INVC_HEADER
                                where (
                                (invoiceheader.INVOICE_DATE >= StartDate && invoiceheader.INVOICE_DATE <= EndDate)
                                && invoiceheader.POST_STATUS == 3
                                && (invoiceheader.INVC_TYPE == "I" || invoiceheader.INVC_TYPE == "M"))
                                select new
                                {
                                    invoiceheader.FOREIGN_AMOUNT
                                };

                    var invoicemtdtotal = query.Sum(o => o.FOREIGN_AMOUNT);
                    if (invoicemtdtotal.HasValue)
                        resultData = Math.Round(invoicemtdtotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceYTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetYTDInvoiceTotals()";
            try
            {
                DateTime StartDate = YTDDate(DateTime.Now);
                DateTime EndDate = DateTime.Now;

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from invoiceheader in dc.INVC_HEADER
                                where (
                                (invoiceheader.INVOICE_DATE >= StartDate && invoiceheader.INVOICE_DATE <= EndDate)
                                && invoiceheader.POST_STATUS == 3
                                && (invoiceheader.INVC_TYPE == "I" || invoiceheader.INVC_TYPE == "M"))
                                select new
                                {
                                    invoiceheader.FOREIGN_AMOUNT
                                };

                    var invoiceytdtotal = query.Sum(o => o.FOREIGN_AMOUNT);
                    if (invoiceytdtotal.HasValue)
                        resultData = Math.Round(invoiceytdtotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceQTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetQTDInvoiceTotals()";
            try
            {
                DateTime StartDate = GetQuarterStartingDate(DateTime.Now);
                DateTime EndDate = GetQuarterEndDate(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from invoiceheader in dc.INVC_HEADER
                                where (
                                (invoiceheader.INVOICE_DATE >= StartDate && invoiceheader.INVOICE_DATE <= EndDate)
                                && invoiceheader.POST_STATUS == 3
                                && (invoiceheader.INVC_TYPE == "I" || invoiceheader.INVC_TYPE == "M"))
                                select new
                                {
                                    invoiceheader.FOREIGN_AMOUNT
                                };

                    var invoiceytdtotal = query.Sum(o => o.FOREIGN_AMOUNT);
                    if (invoiceytdtotal.HasValue)
                        resultData = Math.Round(invoiceytdtotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceLTMTotals()
        {
            decimal resultData;
            const string MethodName = "GetLTMInvoiceTotals()";
            try
            {
                DateTime StartDate = Last12MonthsDate(DateTime.Now);
                DateTime EndDate = DateTime.Now;

                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from invoiceheader in dc.INVC_HEADER
                                where (
                                (invoiceheader.INVOICE_DATE >= StartDate && invoiceheader.INVOICE_DATE <= EndDate)
                                && invoiceheader.POST_STATUS == 3
                                && (invoiceheader.INVC_TYPE == "I" || invoiceheader.INVC_TYPE == "M"))
                                select new
                                {
                                    invoiceheader.FOREIGN_AMOUNT
                                };

                    var invoiceytdtotal = query.Sum(o => o.FOREIGN_AMOUNT);
                    if (invoiceytdtotal.HasValue)
                        resultData = Math.Round(invoiceytdtotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetInvoiceTotals()
        {
            AllTotals resultData;
            const string MethodName = "GetInvoiceTotals()";
            try
            {
                DateTime TodaysDate = DateTime.Now;
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                decimal TodayINV = this.GetInvoiceTodayTotals();
                decimal MTDINV = this.GetInvoiceMTDTotals();
                decimal YTDINV = this.GetInvoiceYTDTotals();
                decimal QTDINV = this.GetInvoiceQTDTotals();
                decimal LTMINV = this.GetInvoiceLTMTotals();

                resultData = new AllTotals() { TodayTotals = TodayINV, MTDTotals = MTDINV, YTDTotals = YTDINV, QTDTotals = QTDINV, LTMTotals = LTMINV };
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        #endregion

        #region Purchase Order Totals
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderTodayTotals()
        {
            decimal resultData;
            const string MethodName = "GetPurchaseOrderTodayTotals()";
            try
            {
                DateTime TodayDate = DateTime.Now;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from po in dc.PO_HEADER
                                where
                                (
                                    po.ENTRY_DATE.Day == TodayDate.Day
                                   && po.ENTRY_DATE.Month == TodayDate.Month
                                   && po.ENTRY_DATE.Year == TodayDate.Year
                                )
                                select new
                                {
                                    TotalCost = po.TOTAL_COST
                                };
                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderMTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetPurchaseOrderMTDTotals()";
            try
            {
                DateTime StartDate = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from po in dc.PO_HEADER
                                where (po.ENTRY_DATE >= StartDate && po.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = po.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderYTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetPurchaseOrderYTDTotals()";
            try
            {
                DateTime StartDate = YTDDate(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from po in dc.PO_HEADER
                                where (po.ENTRY_DATE >= StartDate && po.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = po.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderQTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetPurchaseOrderQTDTotals()";
            try
            {
                DateTime StartDate = GetQuarterStartingDate(DateTime.Now);
                DateTime EndDate = GetQuarterEndDate(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from po in dc.PO_HEADER
                                where (po.ENTRY_DATE >= StartDate && po.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = po.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderLTMTotals()
        {
            decimal resultData;
            const string MethodName = "GetPurchaseOrderLTMTotals()";
            try
            {
                DateTime StartDate = Last12MonthsDate(DateTime.Now);
                DateTime EndDate = DateTime.Now;

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from po in dc.PO_HEADER
                                where (po.ENTRY_DATE >= StartDate && po.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = po.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetPurchaseOrderTotals()
        {
            AllTotals resultData;
            const string MethodName = "GetPurchaseOrderTotals()";
            try
            {
                DateTime TodaysDate = DateTime.Now;
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                decimal TodayPO = GetPurchaseOrderTodayTotals();
                decimal MTDPO = GetPurchaseOrderMTDTotals();
                decimal YTDPO = GetPurchaseOrderYTDTotals();
                decimal QTDPO = GetPurchaseOrderQTDTotals();
                decimal LTMPO = GetPurchaseOrderLTMTotals();

                resultData = new AllTotals() { TodayTotals = TodayPO, MTDTotals = MTDPO, YTDTotals = YTDPO, QTDTotals = QTDPO, LTMTotals = LTMPO };
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        #endregion

        #region Repair Order Totals


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RepairOrder> GetRepairOrders()
        {
            IEnumerable<RepairOrder> resultData;
            const string MethodName = "GetRepairOrders()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from rodetail in dc.RO_DETAIL
                                where
                                rodetail.RO_HEADER.OPEN_FLAG == "T"
                                orderby rodetail.RO_HEADER.ENTRY_DATE ascending
                                select new
                                {
                                    RoDetail = rodetail
                                };
                    var tt = query.Select(rsdetail => new RepairOrder
                    {
                        ComapanyName = rsdetail.RoDetail.RO_HEADER.VENDOR_NAME,
                        RONumber = rsdetail.RoDetail.RO_HEADER.RO_NUMBER,
                        EntryDate = rsdetail.RoDetail.RO_HEADER.ENTRY_DATE,
                        PartNumber = rsdetail.RoDetail.PARTS_MASTER.PN,
                        SONumber = rsdetail.RoDetail.SO_DETAIL1.SO_HEADER.SO_NUMBER,
                        Status = rsdetail.RoDetail.SDF_ROD_010,
                        // AS DISCUSSED RO_UDF_002 IS SENT TO CUSTOMER
                        UDF002 = rsdetail.RoDetail.RO_UDF_002,
                         // AS DISCUSSED RO_UDF_003 RO APPROVED DATE
                        UDF003 = rsdetail.RoDetail.RO_UDF_003
                    }).ToList();
                    resultData = tt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderTodayTotals()
        {
            decimal resultData;
            const string MethodName = "GetPurchaseOrderTodayTotals()";
            try
            {
                DateTime TodayDate = DateTime.Now;
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from ro in dc.RO_HEADER
                                where
                                (
                                    ro.ENTRY_DATE.Day == TodayDate.Day
                                   && ro.ENTRY_DATE.Month == TodayDate.Month
                                   && ro.ENTRY_DATE.Year == TodayDate.Year
                                )
                                select new
                                {
                                    TotalCost = ro.TOTAL_COST
                                };
                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderMTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetRepairOrderMTDTotals()";
            try
            {
                DateTime StartDate = FirstDayOfMonth(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from ro in dc.RO_HEADER
                                where (ro.ENTRY_DATE >= StartDate && ro.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = ro.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderYTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetRepairOrderYTDTotals()";
            try
            {
                DateTime StartDate = YTDDate(DateTime.Now);
                DateTime EndDate = LastDayOfMonth(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from ro in dc.RO_HEADER
                                where (ro.ENTRY_DATE >= StartDate && ro.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = ro.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderQTDTotals()
        {
            decimal resultData;
            const string MethodName = "GetRepairOrderQTDTotals()";
            try
            {
                DateTime StartDate = GetQuarterStartingDate(DateTime.Now);
                DateTime EndDate = GetQuarterEndDate(DateTime.Now);

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from ro in dc.RO_HEADER
                                where (ro.ENTRY_DATE >= StartDate && ro.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = ro.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderLTMTotals()
        {
            decimal resultData;
            const string MethodName = "GetRepairOrderLTMTotals()";
            try
            {
                DateTime StartDate = Last12MonthsDate(DateTime.Now);
                DateTime EndDate = DateTime.Now;

                using (QuantumEntities dc = new QuantumEntities())
                {

                    var query = from ro in dc.RO_HEADER
                                where (ro.ENTRY_DATE >= StartDate && ro.ENTRY_DATE <= EndDate)
                                select new
                                {
                                    TotalCost = ro.TOTAL_COST
                                };

                    var potodaytotal = query.Sum(o => o.TotalCost);
                    if (potodaytotal.HasValue)
                        resultData = Math.Round(potodaytotal.Value, 0);
                    else resultData = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetRepairOrderTotals()
        {
            AllTotals resultData;
            const string MethodName = "GetRepairOrderTotals()";
            try
            {
                DateTime TodaysDate = DateTime.Now;
                DateTime EndDate = LastDayOfMonth(DateTime.Now);
                decimal TodayRO = GetRepairOrderTodayTotals();
                decimal MTDRO = GetRepairOrderMTDTotals();
                decimal YTDRO = GetRepairOrderYTDTotals();
                decimal QTDRO = GetRepairOrderQTDTotals();
                decimal LTMRO = GetRepairOrderLTMTotals();

                resultData = new AllTotals() { TodayTotals = TodayRO, MTDTotals = MTDRO, YTDTotals = YTDRO, QTDTotals = QTDRO, LTMTotals = LTMRO };
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }

        #endregion

        #region Slaes/Customer Type related
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IEnumerable<SalesByCustomerType> GetSalesByCustomerType(DateTime StartDate, DateTime EndDate)
        {

            IEnumerable<SalesByCustomerType> resultData;
            const string MethodName = "GetSalesByCustomerType()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {

                    DateTime TodaysDate = StartDate;
                    var query = from salesOrder in dc.SO_HEADER
                                where (salesOrder.DATE_CREATED.Value >= StartDate && salesOrder.DATE_CREATED.Value <= EndDate)
                                // where salesOrder.SO_NUMBER =="S15411"
                                select new SalesByCustomerType
                                {
                                    SalesNumber = salesOrder.SO_NUMBER,
                                    Date = salesOrder.DATE_CREATED.Value,
                                    CompanyName = salesOrder.COMPANy.COMPANY_NAME,
                                    TotalCost = salesOrder.TOTAL_COST,
                                    TotalPrice = salesOrder.TOTAL_PRICE,
                                    Customer = salesOrder.COMPANy.CUSTOMER_FLAG,
                                    Vendor = salesOrder.COMPANy.VENDOR_FLAG,
                                    Airline = salesOrder.COMPANy.CV_UDF_001,
                                    MROFBO = salesOrder.COMPANy.CV_UDF_002,
                                    BrokerSerious = salesOrder.COMPANy.CV_UDF_003,
                                    Broker = salesOrder.COMPANy.CV_UDF_004,
                                    OEM = salesOrder.COMPANy.CV_UDF_005,
                                    MROAPPD = salesOrder.COMPANy.CV_UDF_006,
                                    SUPAPPD = salesOrder.COMPANy.CV_UDF_007
                                };

                    resultData = query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IEnumerable<SalesByCustomerTypeStats> GetSalesByCustomerTypeStats(DateTime StartDate, DateTime EndDate)
        {
            IEnumerable<SalesByCustomerTypeStats> resultData;
            const string MethodName = "GetSalesByCustomerTypeStats()";
            try
            {
                var vm = new SalesByCustomerTypeViewModel(this.GetSalesByCustomerType(StartDate, EndDate));
                resultData = vm.GetSalesByCustomerTypeStats();
            }

            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
            return resultData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IEnumerable<SalesByAirCraftType> GetSalesByAirCraftType(DateTime StartDate, DateTime EndDate)
        {
            IEnumerable<SalesByAirCraftType> resultData;
            const string MethodName = "GetSalesByAirCraftType()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from invdetail in dc.INVC_DETAIL
                                where (invdetail.INVC_HEADER.POST_DATE.HasValue && invdetail.INVC_HEADER.POST_DATE >= StartDate && invdetail.INVC_HEADER.POST_DATE <= EndDate)
                                select new SalesByAirCraftType
                                {
                                    InvoiceNumber = invdetail.INVC_HEADER.INVC_NUMBER,
                                    PostDate = invdetail.INVC_HEADER.POST_DATE.Value,
                                    Description = invdetail.PARTS_MASTER.DESCRIPTION,
                                    PartNumber = invdetail.PARTS_MASTER.PN,
                                    ChargeType = invdetail.ROUTE_CODE,
                                    UnitPrice = invdetail.QTY_SHIP.HasValue ? invdetail.QTY_SHIP.Value : 0,
                                    TotalAmount = invdetail.QTY_SHIP.HasValue ? (invdetail.QTY_SHIP.Value * invdetail.UNIT_PRICE.Value) : 0,
                                    Quantity = invdetail.QTY_SHIP.HasValue ? invdetail.QTY_SHIP.Value : 0,
                                    ApplicationCode = invdetail.PARTS_MASTER != null ? invdetail.PARTS_MASTER.MASTER_FLAG == "F" ? "CHARGE" : invdetail.PARTS_MASTER.APPLICATION_CODES.APPLICATION_CODE : "",
                                    HasApplicationCode = invdetail.PARTS_MASTER != null && invdetail.PARTS_MASTER.MASTER_FLAG != "F" ? true : false
                                };

                    resultData = query.ToList().Where(o => o.HasApplicationCode).Select(o => o).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast3months()
        {
            IEnumerable<SalesByAirCraftTypeStats> resultData;
            const string MethodName = "GetSalesByAirCraftTypeLast3months()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    DateTime queryDate = this.Last3MonthsDate(DateTime.Now.Date);
                    var query = from invdetail in dc.INVC_DETAIL
                                where (invdetail.INVC_HEADER.POST_DATE.HasValue && invdetail.INVC_HEADER.POST_DATE >= queryDate)

                                select new SalesByAirCraftType
                                {
                                    InvoiceNumber = invdetail.INVC_HEADER.INVC_NUMBER,
                                    PostDate = invdetail.INVC_HEADER.POST_DATE.Value,
                                    Description = invdetail.PARTS_MASTER.DESCRIPTION,
                                    PartNumber = invdetail.PARTS_MASTER.PN,
                                    ChargeType = invdetail.ROUTE_CODE,
                                    UnitPrice = invdetail.QTY_SHIP.HasValue ? invdetail.QTY_SHIP.Value : 0,
                                    TotalAmount = invdetail.QTY_SHIP.HasValue ? (invdetail.QTY_SHIP.Value * invdetail.UNIT_PRICE.Value) : 0,
                                    Quantity = invdetail.QTY_SHIP.HasValue ? invdetail.QTY_SHIP.Value : 0,
                                    ApplicationCode = invdetail.PARTS_MASTER != null ? invdetail.PARTS_MASTER.MASTER_FLAG == "F" ? "CHARGE" : invdetail.PARTS_MASTER.APPLICATION_CODES.APPLICATION_CODE : "",
                                    HasApplicationCode = invdetail.PARTS_MASTER != null && invdetail.PARTS_MASTER.MASTER_FLAG != "F" ? true : false
                                };

                    var filteredList = query.ToList().Where(o => o.HasApplicationCode).Select(o => o).ToList();
                    var totalSales = filteredList.Sum(o => o.TotalAmount);

                    resultData = (from f in filteredList

                                  group f by f.ApplicationCode into grp
                                  select new SalesByAirCraftTypeStats
                                  {
                                      AirCraftType = grp.Key,
                                      TotalSalesAmount = grp.Sum(o => o.TotalAmount),
                                      Percentage = ((double)(grp.Sum(o => o.TotalAmount) / totalSales)) * 100
                                         ,
                                      ImageName = grp.Key.Replace("/", "").Replace("-", "").Replace(" ", "")
                                  }).OrderByDescending(a => a.TotalSalesAmount).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast12months()
        {

            IEnumerable<SalesByAirCraftTypeStats> resultData;
            const string MethodName = "GetSalesByAirCraftTypeLast12months()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    DateTime queryDate = this.YTDDate(DateTime.Now.Date);
                    var query = from invdetail in dc.INVC_DETAIL
                                where (invdetail.INVC_HEADER.POST_DATE.HasValue && invdetail.INVC_HEADER.POST_DATE >= queryDate)

                                select new SalesByAirCraftType
                                {
                                    InvoiceNumber = invdetail.INVC_HEADER.INVC_NUMBER,
                                    PostDate = invdetail.INVC_HEADER.POST_DATE.Value,
                                    Description = invdetail.PARTS_MASTER.DESCRIPTION,
                                    PartNumber = invdetail.PARTS_MASTER.PN,
                                    ChargeType = invdetail.ROUTE_CODE,
                                    UnitPrice = invdetail.QTY_SHIP.HasValue ? invdetail.QTY_SHIP.Value : 0,
                                    TotalAmount = invdetail.QTY_SHIP.HasValue ? (invdetail.QTY_SHIP.Value * invdetail.UNIT_PRICE.Value) : 0,
                                    Quantity = invdetail.QTY_SHIP.HasValue ? invdetail.QTY_SHIP.Value : 0,
                                    ApplicationCode = invdetail.PARTS_MASTER != null ? invdetail.PARTS_MASTER.MASTER_FLAG == "F" ? "CHARGE" : invdetail.PARTS_MASTER.APPLICATION_CODES.APPLICATION_CODE : "",
                                    HasApplicationCode = invdetail.PARTS_MASTER != null && invdetail.PARTS_MASTER.MASTER_FLAG != "F" ? true : false
                                };

                    var filteredList = query.ToList().Where(o => o.HasApplicationCode).Select(o => o).ToList();
                    var totalSales = filteredList.Sum(o => o.TotalAmount);
                    resultData = (from f in filteredList

                                  group f by f.ApplicationCode into grp
                                  select new SalesByAirCraftTypeStats
                                  {
                                      AirCraftType = grp.Key,
                                      TotalSalesAmount = grp.Sum(o => o.TotalAmount),
                                      Percentage = ((double)(grp.Sum(o => o.TotalAmount) / totalSales)) * 100
                                         ,
                                      ImageName = grp.Key.Replace("/", "").Replace("-", "").Replace(" ", "")
                                  }).OrderByDescending(a => a.TotalSalesAmount).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }

            return resultData;
        }
        #endregion

        #region Helper Functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime FirstDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime LastDayOfMonth(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime Last12MonthsDate(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            return firstDayOfTheMonth.AddMonths(-12).AddDays(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime YTDDate(DateTime dateTime)
        {
            DateTime YTDDate = new DateTime(dateTime.Year, 1, 1);
            // DateTime lastDay = new DateTime(year, 12, 31);
            return YTDDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime Last3MonthsDate(DateTime dateTime)
        {
            DateTime last3MonthsDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            return last3MonthsDate.AddMonths(-3).AddDays(-1);
        }

        /// <summary>
        /// Current Quater
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        public int GetQuarterName(DateTime myDate)
        {
            return (int)Math.Ceiling(myDate.Month / 3.0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        public DateTime GetQuarterStartingDate(DateTime myDate)
        {
            return new DateTime(myDate.Year, (3 * GetQuarterName(myDate)) - 2, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        public DateTime GetQuarterEndDate(DateTime myDate)
        {
            return new DateTime(myDate.Year, (3 * GetQuarterName(myDate)), 1).AddMonths(1).AddDays(-1);
        }

        //public static void Main(string[] args)
        //{

        //    var mydate = Convert.ToDateTime("1-12-2020");
        //    //var mydate = DateTime.Now;
        //    Console.WriteLine(Math.Ceiling(mydate.Month / 3m));
        //    Console.WriteLine(GetQuarterStartingDate(mydate));
        //    Console.WriteLine(GetQuarterEndDate(mydate));

        //}

        #endregion
    }
}
