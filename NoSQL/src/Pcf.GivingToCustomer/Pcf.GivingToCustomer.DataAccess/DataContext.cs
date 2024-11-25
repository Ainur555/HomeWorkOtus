using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.DataAccess.Data;

namespace Pcf.GivingToCustomer.DataAccess
{
    public class DataContext
    {
        private IMongoDatabase _db { get; set; }

        public IMongoDatabase Database => _db;
        public IMongoCollection<Customer> Customers => _db.GetCollection<Customer>("Customers");
        public IMongoCollection<PromoCode> PromoCode => _db.GetCollection<PromoCode>("PromoCodes");
        public IMongoCollection<Preference> Preference => _db.GetCollection<Preference>("Preferences");
        public DataContext(IMongoClient mongoClient, string databaseName)
        {
            _db = mongoClient.GetDatabase(databaseName);
        }         
    }
}