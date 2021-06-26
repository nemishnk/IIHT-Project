using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace priceDataLayer
{
    public class Pricedata
    {
        public async Task<List<PriceModel>> AddPriceAsync(List<PriceModel> prices)
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var collection = DB.GetCollection<PriceModel>("CompanyPriceDetails");
            await collection.InsertManyAsync(prices);
            return prices;
        }
        public  List<PriceModel> GetAllPrices()
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var collection = DB.GetCollection<PriceModel>("CompanyPriceDetails").Find(new BsonDocument()).ToList();
            
            return collection;
        }

        public List<PriceModel> GetAllPriceForCompany(string companycode)
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var filter = Builders<PriceModel>.Filter.Eq(x => x.CompanyCode, companycode);
            var collection = DB.GetCollection<PriceModel>("CompanyPriceDetails").Find(filter).ToList();
            return collection;
        }
        
        public List<PriceModel> GetPricedetails(string CompanyCode, DateTime Startdate, DateTime Enddate)
        {
            var Filterbycompanycode = GetAllPriceForCompany(CompanyCode);
            var x = Startdate.Date;
            List<PriceModel> Result = Filterbycompanycode.Where(c => c.DateAndTime.Ticks > Startdate.Ticks && c.DateAndTime.Ticks < Enddate.Ticks).ToList();

            return Result;
        }

        public dynamic GetHistogramDetails(DateTime date , string CompanyCode)
        {
            var Filterbycompanycode = GetAllPriceForCompany(CompanyCode);
            var Maxprice = Filterbycompanycode.Max(c=>c.value);
            var Minprice = Filterbycompanycode.Min(c => c.value);
            var Averageprice = Filterbycompanycode.Average(c => c.value);
            var result = new
            {
                Maxprice = Maxprice,
                Minprice = Minprice,
                Averageprice =Averageprice
            };
            return result;

        }
    }
}
