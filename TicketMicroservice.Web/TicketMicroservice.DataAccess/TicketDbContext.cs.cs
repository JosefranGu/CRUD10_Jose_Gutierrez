using Microsoft.EntityFrameworkCore;
using TicketMicroservice.Core;

namespace TicketMicroservice.DataAccess
{
    public class TicketDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {
        }
    }
}
