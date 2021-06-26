using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    [BsonIgnoreExtraElements]
    public class CompanyModel
    {
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string CEO { get; set; }
        public int TurnOver { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Exchange { get; set; }
        
    }
}
