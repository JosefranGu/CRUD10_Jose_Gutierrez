// TicketController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using TicketMicroservice.ApplicationServices;
using TicketMicroservice.Core;
using TicketMicroservice.Web;
using Serilog;

namespace Ticket.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IChecker _checker;

        public TicketController(ITicketService ticketService, IChecker checker)
        {
            _ticketService = ticketService;
            _checker = checker;
        }

        // Implementar acciones CRUD y autorización JWT
        // In TicketController.cs
        [HttpPost]
        public IActionResult Insert(Ticket ticketDTO)
        {
            try
            {
                // Validate existence using Checker class
                var existenceCheck = _checker.CheckJourneyAndPassengerExistence(ticketDTO.JourneyId, ticketDTO.PassengerId).Result;
                if (!existenceCheck)
                {
                    return BadRequest("JourneyId or PassengerId does not exist.");
                }

                // Insert logic
                _ticketService.Insert(ticketDTO);

                return Ok("Ticket inserted successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "An error occurred during Ticket insertion.");

                // Return a generic error response
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        // Implement similar try-catch blocks in other actions...

    }
}
