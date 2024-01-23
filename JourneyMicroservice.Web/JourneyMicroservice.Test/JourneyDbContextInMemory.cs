using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JourneyMicroservice.Core;

namespace JourneyMicroservice.Test
{
    public class JourneyDbContextInMemory : DbContext
    {
        public JourneyDbContextInMemory(DbContextOptions<JourneyDbContextInMemory> options)
            : base(options)
        {
        }

        public DbSet<Journey> Journeys { get; set; }
        // Agrega otras DbSet según sea necesario para tus pruebas
    }

}

