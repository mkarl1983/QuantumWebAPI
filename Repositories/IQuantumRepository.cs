using System;
using System.Collections.Generic;
using System.Linq;

using QuantumWebAPI.Models;

namespace QuantumWebAPI.Repositories
{
    /// <summary>
    /// IQuantumRepository for Oracle DB
    /// </summary>
    public interface IQuantumRepository
    {
        #region Shipping 

        /// <summary>
        /// GetShippingFeeds
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shipping> GetShippingFeeds();


        /// <summary>
        /// GetWarehouseShipmentsAndRepairsOrders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shipping> GetWarehouseShipmentsAndRepairsOrders();

        #endregion

        #region Sales 
        /// <summary>
        /// GetSalesOrdersFeed for Today
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesOrder> GetSalesOrdersFeed();

        /// <summary>
        /// Get Sales Count by start date and end date where start date uses only date component and enddate uses date and time component.
        /// for example todays sales count start and end date is today but start and end time is different
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public int GetSalesOrdersCount(DateTime StartDate, DateTime EndDate);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesTodayTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesMTDTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesYTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesQTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetSalesLTMTotals();


        /// <summary>
        /// Get Sales Totals By Start and End Date.
        /// if no start or end date is given it will send result for todays sales totals
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public decimal GetSalesTotalsByStartEndDate(DateTime? StartDate, DateTime? EndDate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllRatioTotals GetSaleOrderToQuoteRatios();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetSalesOrderTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetSalesOrderTotals_Old();

        #endregion

        #region Quotes 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public int GetQuotesCount(DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// GetQuoteFeeds
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Quote> GetQuoteFeeds();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public decimal GetYTDQuotesTotals(DateTime StartDate, DateTime EndDate);


        #endregion

        #region PartNumber Stats

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PartNumberHit> GetPartNumberTodayHits();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodRecevied> GetGRNFeeds();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PartNumberHit> GetPartNumber30DayHits();

        #endregion

        #region Employee Totals


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeQuotes> GetEmployeeTodayQuotes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSales> GetEmployeeMTDSalesOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeQuotes> GetEmployeeMTDQuotes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSales> GetEmployeeTodaySalesOrders();

        #endregion

        #region  Invoice Order Totals

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceTodayTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceMTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceYTDTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceQTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetInvoiceLTMTotals();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetInvoiceTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetInvoiceTotals_Old();

        #endregion

        #region Purchase Order Totals
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderTodayTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderMTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderYTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderQTDTotals();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetPurchaseOrderLTMTotals();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetPurchaseOrderTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetPurchaseOrderTotals_Old();

        #endregion

        #region Repair Order Totals


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RepairOrder> GetRepairOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderTodayTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderMTDTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderYTDTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderQTDTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetRepairOrderLTMTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetRepairOrderTotals();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AllTotals GetRepairOrderTotals_Old();

        #endregion

        #region Slaes/Customer Type related
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IEnumerable<SalesByCustomerType> GetSalesByCustomerType(DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IEnumerable<SalesByCustomerTypeStats> GetSalesByCustomerTypeStats(DateTime StartDate, DateTime EndDate);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IEnumerable<SalesByAirCraftType> GetSalesByAirCraftType(DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast3months();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast12months();
        #endregion

    }
}
