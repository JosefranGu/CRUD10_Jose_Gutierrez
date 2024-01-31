﻿using Microsoft.EntityFrameworkCore;
using TicketMicroservice.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengersMicroservice.Tests
{
    public class TicketDbContextInMemory : DbContext
    {
        public TicketDbContextInMemory(DbContextOptions<TicketDbContextInMemory> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Passengers { get; set; }
        // Añadir otras DbSet según sea necesario para tus pruebas
    }

}
