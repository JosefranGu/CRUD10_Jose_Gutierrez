using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core;

namespace TicketMicroservice.DataAccess
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _dbContext;

        public TicketRepository(TicketDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _dbContext.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            return _dbContext.Tickets.Find(id);
        }

        public void Insert(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var ticket = _dbContext.Tickets.Find(id);
            if (ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
                _dbContext.SaveChanges();
            }
        }
    }
}
