using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using MongoDB.Bson;

namespace CompanyDataLayer
{
    public class CompanyDL
    {
        public async Task<CompanyModel> RegisterCompanyAsync(CompanyModel model)
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var collection = DB.GetCollection<CompanyModel>("CompanyDetails");
            await collection.InsertOneAsync(model);
            return model;
        }

        public CompanyModel GetCompanyInfo(string CompanyCode)
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var collection = DB.GetCollection<CompanyModel>("CompanyDetails").Find(new BsonDocument()).ToList();
            var Result = collection.Where(c => c.CompanyCode == CompanyCode).FirstOrDefault();
            return Result;
        }

        public List<CompanyModel> GetAllCompany()
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var collection = DB.GetCollection<CompanyModel>("CompanyDetails").Find(new BsonDocument()).ToList();
            return collection;
        }

        public async Task<long> DeleteCompanyAsync(string CompanyCode)
        {
            string constr = "mongodb://localhost:27017";
            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Company");
            var collection =  await DB.GetCollection<CompanyModel>("CompanyDetails").DeleteOneAsync(
                Builders<CompanyModel>.Filter.Eq("CompanyCode", CompanyCode));
            
            return collection.DeletedCount;
        }

        
    }
}
