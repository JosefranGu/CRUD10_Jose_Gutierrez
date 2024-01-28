﻿// TicketService.cs
using TicketMicroservice.Core;
using TicketMicroservice.DataAccess;

namespace TicketMicroservice.ApplicationServices
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IChecker _checker;

        public TicketService(ITicketRepository ticketRepository, IChecker checker)
        {
            _ticketRepository = ticketRepository;
            _checker = checker;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public void InsertTicket(Ticket ticket)
        {
            // Verifica existencia de JourneyId y PassengerId antes de insertar
            if (!_checker.CheckJourneyAndPassengerExistence(ticket.JourneyId, ticket.PassengerId))
                throw new InvalidOperationException("Invalid JourneyId or PassengerId.");

            _ticketRepository.Insert(ticket);
        }

        public void EditTicket(Ticket ticket)
        {
            // Verifica existencia de JourneyId y PassengerId antes de editar
            if (!_checker.CheckJourneyAndPassengerExistence(ticket.JourneyId, ticket.PassengerId))
                throw new InvalidOperationException("Invalid JourneyId or PassengerId.");

            _ticketRepository.Update(ticket);
        }

        public void DeleteTicket(int id)
        {
            _ticketRepository.Delete(id);
        }
    }
}
