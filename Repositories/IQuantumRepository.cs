using System;
using System.Collections.Generic;
using System.Linq;

using QuantumWebAPI.Models;

namespace QuantumWebAPI.Repositories
{
     public interface IQuantumRepository
    {
        #region Shipping
        IEnumerable<Shipping> GetShippingFeeds();

         IEnumerable<Shipping> GetWarehouseShipmentsAndRepairsOrders();
        #endregion

        #region Employee Part Number, Related Totals
         IEnumerable<PartNumberHit> GetPartNumberHits();

         IEnumerable<GoodRecevied> GetGRNFeeds();

         IEnumerable<PartNumberHit> GetPartNumber30DayHits();

         IEnumerable<EmployeeSales> GetTotalEmployeeSales();

         IEnumerable<EmployeeQuotes> GetTotalEmployeeQuotes();

         IEnumerable<EmployeeSales> GetEmployeeMTDSalesOrders();

         IEnumerable<EmployeeQuotes> GetEmployeeMTDQuotes();

        #endregion

        #region Invoice Totals
         decimal GetInvoiceTodayTotals();
         decimal GetInvoiceMTDTotals();
         decimal GetYTDInvoiceTotals();
         decimal GetQTDInvoiceTotals();
         decimal GetLTMInvoiceTotals();
        #endregion

        #region Sales and Quotes Totals

        IEnumerable<SalesOrder> GetSalesOrders();
         IEnumerable<Quote> GetQuoteFeeds();

         int GetSalesCount(DateTime StartDate, DateTime EndDate);
         decimal GetYTDSalesTotals();


         decimal GetQTDSalesTotals();


         decimal GetLTMSalesTotals();



         decimal GetYTDQuotesTotals(DateTime StartDate, DateTime EndDate);
       

         int GetQuotesCount(DateTime StartDate, DateTime EndDate);

         SaleOrderToQuoteRatio GetSaleOrderToQuoteRatios();

        #endregion

        #region Purchase Order Totals

         decimal GetPurchaseOrderTodayTotals();


         decimal GetPurchaseOrderMTDTotals();


         decimal GetPurchaseOrderYTDTotals();


         decimal GetPurchaseOrderQTDTotals();

         decimal GetPurchaseOrderLTMTotals();

        #endregion

        #region Repair Order Totals

         IEnumerable<RepairOrder> GetRepairOrders();
         decimal GetRepairOrderTodayTotals();

         decimal GetRepairOrderMTDTotals();

         decimal GetRepairOrderYTDTotals();

         decimal GetRepairOrderQTDTotals();

         decimal GetRepairOrderLTMTotals();

        #endregion

        #region Purchase Order Totals
         PurchaseOrderTotals GetPurchaseOrderTotals();
        #endregion

        #region Repair Order Totals
         RepairOrderTotals GetRepairOrderTotals();
        #endregion

        #region Slaes/Customer Type related
         IEnumerable<SalesByCustomerType> GetSalesByCustomerType(DateTime StartDate, DateTime EndDate);

         IEnumerable<SalesByCustomerTypeStats> GetSalesByCustomerTypeStats(DateTime StartDate, DateTime EndDate);

         IEnumerable<SalesByAirCraftType> GetSalesByAirCraftType(DateTime StartDate, DateTime EndDate);


         IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast3months();

         IEnumerable<SalesByAirCraftTypeStats> GetSalesByAirCraftTypeLast12months();

        #endregion

    }
}
