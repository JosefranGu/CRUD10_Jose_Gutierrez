using Microsoft.AspNetCore.Mvc;
using PassengersMicroservice.Core;

namespace PassengersMicroservice.Web.Controllers
{
    // PassengersController.cs
    [ApiController]
    [Route("api/passengers")]
    public class PassengersController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengersController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        public ActionResult<List<Passenger>> GetAll()
        {
            var passengers = _passengerService.GetAll();
            return Ok(passengers);
        }

        [HttpGet("{id}")]
        public ActionResult<Passenger> GetById(int id)
        {
            var passenger = _passengerService.GetById(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger);
        }

        [HttpPost]
        public ActionResult Insert([FromBody] Passenger passengerDTO)
        {
            _passengerService.Insert(passengerDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] Passenger passengerDTO)
        {
            var existingPassenger = _passengerService.GetById(id);

            if (existingPassenger == null)
            {
                return NotFound();
            }

            _passengerService.Edit(passengerDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _passengerService.Delete(id);
            return Ok();
        }
    }

}
