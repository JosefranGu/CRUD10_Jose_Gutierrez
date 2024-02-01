// TicketController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using TicketMicroservice.ApplicationServices;
using TicketMicroservice.Core; // Agrega esta línea para corregir el error CS0118
using TicketMicroservice.Web;
using Serilog;


namespace TicketMicroservice.Web.Controllers
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
        public IActionResult Insert(Ticket ticket)
        {
            try
            {
                // Validate existence using Checker class
                var existenceCheck = _checker.CheckJourneyAndPassengerExistence(ticket.JourneyId, ticket.PassengerId).Result;
                if (!existenceCheck)
                {
                    return BadRequest("JourneyId or PassengerId does not exist.");
                }

                // Insert logic
                _ticketService.InsertTicket(ticket);

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
