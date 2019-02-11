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
        public ActionResult<List<Trucks>> Get()
        {
            return _truckService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTruck")]
        public ActionResult<Trucks> Get(string id)
        {
            var book = _truckService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Trucks> Create(Trucks truck)
        {
            _truckService.Create(truck);

            return CreatedAtRoute("GetTruck", new { id = truck.Id.ToString() }, truck);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Trucks truckIn)
        {
            var truck = _truckService.Get(id);

            if (truck == null)
            {
                return NotFound();
            }

            _truckService.Update(id, truckIn);

            return NoContent();
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