using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumWebAPI.Models

{

    public class SalesByCustomerTypeStats
    {
        
        public double Percentage { get; set; }
        public int CustomerCount { get; set; }
        public string CustomerType { get; set; }


    }



    public class SalesByCustomerTypeViewModel
    {

        private IEnumerable<SalesByCustomerType> _salesCollection;
        private double _totalSalesAmount;

        public double TotalSalesAmount
        {
            get { return _totalSalesAmount; }
            set { _totalSalesAmount = value; }
        }


        public IEnumerable<SalesByCustomerType> SalesCollection
        {
            get { return _salesCollection; }
            set { _salesCollection = value; }
        }

        public SalesByCustomerTypeViewModel(IEnumerable<SalesByCustomerType> Collection)
        {
            this.SalesCollection = Collection;
            this.TotalSalesAmount = Convert.ToDouble( this.SalesCollection.Sum(o => o.TotalPrice));
        }

        public double GetTotalSalesCount()
        {
            return TotalSalesAmount;
        }

        public List<SalesByCustomerTypeStats> GetSalesByCustomerTypeStats()
        {

            var stats = new List<SalesByCustomerTypeStats>();

            if (this.SalesCollection.Any())
            {
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "Airline", CustomerCount = this.SalesCollection.Where(o => o.Airline == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.Airline == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
                // stats.Add(new SalesByCustomerTypeStats { CustomerType = "Customer", CustomerCount = this.SalesCollection.Where(o => o.Customer == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.Customer == "T").Count() / this.TotalSalesAmount) * 100, 2) });
                //  stats.Add(new SalesByCustomerTypeStats { CustomerType = "Vendor", CustomerCount = this.SalesCollection.Where(o => o.Vendor == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.Vendor == "T").Count() / this.TotalSalesAmount) * 100, 2) });
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "MROFBO", CustomerCount = this.SalesCollection.Where(o => o.MROFBO == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.MROFBO == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "BrokerSerious", CustomerCount = this.SalesCollection.Where(o => o.BrokerSerious == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.BrokerSerious == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "Broker", CustomerCount = this.SalesCollection.Where(o => o.Broker == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.Broker == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "OEM", CustomerCount = this.SalesCollection.Where(o => o.OEM == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.OEM == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "MROAPPD", CustomerCount = this.SalesCollection.Where(o => o.MROAPPD == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.MROAPPD == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
                stats.Add(new SalesByCustomerTypeStats { CustomerType = "SUPAPPD", CustomerCount = this.SalesCollection.Where(o => o.SUPAPPD == "T").Select(o => o.CompanyName).Distinct().Count(), Percentage = Math.Round(((double)this.SalesCollection.Where(o => o.SUPAPPD == "T").Sum(o => o.TotalPrice) / this.TotalSalesAmount) * 100, 2) });
               
            }

            return stats;
        }



    }
}