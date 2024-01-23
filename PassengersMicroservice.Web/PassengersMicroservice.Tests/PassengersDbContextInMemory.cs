using Microsoft.EntityFrameworkCore;
using PassengersMicroservice.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengersMicroservice.Tests
{
    public class PassengersDbContextInMemory : DbContext
    {
        public PassengersDbContextInMemory(DbContextOptions<PassengersDbContextInMemory> options)
            : base(options)
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        // Añadir otras DbSet según sea necesario para tus pruebas
    }

}
