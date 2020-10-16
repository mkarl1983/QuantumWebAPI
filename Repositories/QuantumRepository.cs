




using QuantumWebAPI.Models;
using QuntumDB.QuantumModel;
using System;
using System.Collections.Generic;
using System.Linq;



namespace QuantumWebAPI.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class QuantumRepository : IQuantumRepository
    {
       
        const string CLASSID = "QuantumRepository";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeQuotes> GetEmployeeMTDQuotes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSales> GetEmployeeMTDSalesOrders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodRecevied> GetGRNFeeds()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceMTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetInvoiceTodayTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetLTMInvoiceTotals()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartNumberHit> GetPartNumber30DayHits()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartNumberHit> GetPartNumberHits()
        {
            const string MethodName = "GetPartNumberHits()";
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

                    return query.Take(5).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
        }

        public PurchaseOrderTotals GetPurchaseOrderTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetQTDInvoiceTotals()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quote> GetQuoteFeeds()
        {
            const string MethodName = "GetQuoteFeeds()";
            try
            {
                using (QuantumEntities dc = new QuantumEntities())
                {
                    var query = from quotedetail in dc.CQ_DETAIL
                                where quotedetail.CQ_HEADER.DATE_CREATED.Value.Day == DateTime.Now.Day &&
                                      quotedetail.CQ_HEADER.DATE_CREATED.Value.Month == DateTime.Now.Month &&
                                      quotedetail.CQ_HEADER.DATE_CREATED.Value.Year == DateTime.Now.Year
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

                    return query.ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(CLASSID + ":" + MethodName + " " + ex.Message);
            }
        }

        public int GetQuotesCount(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepairOrder> GetRepairOrders()
        {
            throw new NotImplementedException();
        }

        public RepairOrderTotals GetRepairOrderTotals()
        {
            throw new NotImplementedException();
        }

        public SaleOrderToQuoteRatio GetSaleOrderToQuoteRatios()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesByAirCraftType> GetSalesByAirCraftType(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast12months()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast3months()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesByCustomerType> GetSalesByCustomerType(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesByCustomerTypeStats> GetSalesByCustomerTypeStats(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public int GetSalesCount(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesOrder> GetSalesOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipping> GetShippingFeeds()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeQuotes> GetTotalEmployeeQuotes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeSales> GetTotalEmployeeSales()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipping> GetWarehouseShipmentsAndRepairsOrders()
        {
            throw new NotImplementedException();
        }

        public decimal GetYTDInvoiceTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetYTDSalesTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetQTDSalesTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetLTMSalesTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetYTDQuotesTotals(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public decimal GetPurchaseOrderTodayTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetPurchaseOrderMTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetPurchaseOrderYTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetPurchaseOrderQTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetPurchaseOrderLTMTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetRepairOrderTodayTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetRepairOrderMTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetRepairOrderYTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetRepairOrderQTDTotals()
        {
            throw new NotImplementedException();
        }

        public decimal GetRepairOrderLTMTotals()
        {
            throw new NotImplementedException();
        }

    }
}
