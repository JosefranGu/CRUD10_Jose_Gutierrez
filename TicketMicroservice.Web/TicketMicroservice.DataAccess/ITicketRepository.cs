using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core;

namespace TicketMicroservice.DataAccess
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        void Insert(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
    }
}
