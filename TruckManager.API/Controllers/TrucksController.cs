using Microsoft.AspNetCore.Mvc;
using TruckManager.API.Models;
using TruckManager.API.Services;
using System.Collections.Generic;

namespace TruckManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly TruckService _truckService;

        public TrucksController(TruckService truckService){
            _truckService = truckService;
        }
        

        [HttpGet]
        public ActionResult<List<Truck>> Get()
        {
            return _truckService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTruck")]
        public ActionResult<Truck> Get(string id)
        {
            var book = _truckService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Truck> Create(Truck truck)
        {
            _truckService.Create(truck);

            return CreatedAtRoute("GetTruck", new { id = truck.Id.ToString() }, truck);
        }


        [HttpPut("{id}")]
        public ActionResult<Truck> AddTanking(string id, [FromBody] Tanking tanking)
        {
            var updatedTruck = _truckService.AddTanking(id, tanking);
            if(updatedTruck == null){
                return NotFound();
            }
            return updatedTruck; 
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var truck = _truckService.Get(id);

            if (truck == null)
            {
                return NotFound();
            }

            _truckService.Remove(truck.Id);

            return NoContent();
        }

    }
}