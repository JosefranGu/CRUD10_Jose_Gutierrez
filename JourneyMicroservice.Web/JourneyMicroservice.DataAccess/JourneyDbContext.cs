using JourneyMicroservice.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.DataAccess
{
    public class JourneyDbContext : DbContext
    {
        public DbSet<Journey> Passengers { get; set; }

        public JourneyDbContext(DbContextOptions<JourneyDbContext> options) : base(options)
        {
        }
    }
}
