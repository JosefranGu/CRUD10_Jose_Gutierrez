using JourneyMicroservice.ApplicationServices;
using JourneyMicroservice.Core;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMicroservice.Web.Controllers
{
    // JourneyController.cs
    [ApiController]
    [Route("api/journeys")]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        [HttpGet]
        public ActionResult<List<Journey>> GetAll()
        {
            var journeys = _journeyService.GetAll();
            return Ok(journeys);
        }

        [HttpGet("{id}")]
        public ActionResult<Journey> GetById(int id)
        {
            var journey = _journeyService.GetById(id);

            if (journey == null)
            {
                return NotFound();
            }

            return Ok(journey);
        }

        [HttpPost]
        public ActionResult Insert([FromBody] Journey journeyDTO)
        {
            _journeyService.Insert(journeyDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] Journey journeyDTO)
        {
            var existingJourney = _journeyService.GetById(id);

            if (existingJourney == null)
            {
                return NotFound();
            }

            _journeyService.Edit(journeyDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _journeyService.Delete(id);
            return Ok();
        }
    }
}
