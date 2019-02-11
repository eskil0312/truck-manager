using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TruckManager.API.Models;

namespace TruckManager.API.Services
{
    public class TruckService
    {
        private readonly IMongoCollection<Trucks> _trucks;

        public TruckService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TruckmanagerDb"));
            var database = client.GetDatabase("TruckmanagerDb");
            _trucks = database.GetCollection<Trucks>("Trucks");
        }

        public List<Trucks> Get()
        {
            return _trucks.Find(truck => true).ToList();
        }

        public Trucks Get(string id)
        {
            return _trucks.Find<Trucks>(truck => truck.Id == id).FirstOrDefault();
        }

         public Trucks Create(Trucks truck)
        {
            _trucks.InsertOne(truck);
            return truck;
        }
        public void Update(string id, Trucks truckIn)
        {
            _trucks.ReplaceOne(truck => truck.Id == id, truckIn);
        }

         public void Remove(Trucks truckIn)
        {
            _trucks.DeleteOne(truck => truck.Id == truckIn.Id);
        }

        public void Remove(string id)
        {
            _trucks.DeleteOne(truck => truck.Id == id);
        }
        
    }
}