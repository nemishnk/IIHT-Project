using Models;
using priceDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBusinessLayer
{
    public class PriceBusiness
    {
        Pricedata datalayer = new Pricedata();
        public async Task<List<PriceModel>> AddPriceAsync(List<PriceModel> prices)
        {
            var result = await datalayer.AddPriceAsync(prices);

            var test = datalayer.GetAllPriceForCompany("string");
            return result;
        }


        public List<PriceModel> GetPricedetails(string CompanyCode, DateTime Startdate, DateTime Enddate)
        {
            var result = datalayer.GetPricedetails(CompanyCode, Startdate, Enddate);
            return result;
        }

        public dynamic GetHistogramonday( DateTime Date, string CompanyCode)
        {
            var result = datalayer.GetHistogramDetails(Date,CompanyCode);
            return result;
        }
    }
}
