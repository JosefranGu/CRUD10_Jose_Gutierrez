using PassengersMicroservice.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengersMicroservice.DataAccess
{
    public class PassengersDbContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }

        public PassengersDbContext(DbContextOptions<PassengersDbContext> options) : base(options)
        {
        }
    }
}
