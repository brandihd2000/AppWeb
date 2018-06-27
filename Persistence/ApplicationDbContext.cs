using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Observaciones> Observaciones { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Tratamiento> Tratamiento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
