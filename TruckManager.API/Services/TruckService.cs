using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TruckManager.API.Models;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace TruckManager.API.Services
{
    public class TruckService
    {
        private readonly IMongoCollection<Truck> _trucks;

        public TruckService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TruckmanagerDb"));
            var database = client.GetDatabase("TruckmanagerDb");
            _trucks = database.GetCollection<Truck>("Trucks");
        }

        public List<Truck> Get()
        {
            return _trucks.Find(truck => true).ToList();
        }

        public Truck Get(string id)
        {
            return _trucks.Find<Truck>(truck => truck.Id == id).FirstOrDefault();
        }

         public Truck Create(Truck truck)
        {
            _trucks.InsertOne(truck);
            return truck;
        }
        public void Update(string id, Truck truckIn)
        {
            _trucks.ReplaceOne(truck => truck.Id == id, truckIn);
        }

         public void Remove(Truck truckIn)
        {
            _trucks.DeleteOne(truck => truck.Id == truckIn.Id);
        }

        public void Remove(string id)
        {
            _trucks.DeleteOne(truck => truck.Id == id);
        }
        public Truck AddTanking(string id, Tanking newTanking)
        {
            //Tanking newTanking = JsonConvert.DeserializeObject<Tanking>(tanking);

            var updatedTruck = _trucks.Find<Truck>(truck => truck.Id == id).FirstOrDefault();
            if (updatedTruck == null){
                return null;
            }
            updatedTruck.Tankings.Add(newTanking);
            _trucks.ReplaceOne(truck => truck.Id == id, updatedTruck);
            return updatedTruck;

        }
        
    }
}