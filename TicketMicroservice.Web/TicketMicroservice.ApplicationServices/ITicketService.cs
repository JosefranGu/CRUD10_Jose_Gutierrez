using TicketMicroservice.Core;

namespace TicketMicroservice.ApplicationServices
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void InsertTicket(Ticket ticket);
        void EditTicket(Ticket ticket);
        void DeleteTicket(int id);
    }
}
