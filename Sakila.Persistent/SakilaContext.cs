using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent
{
    public class SakilaContext : AuditTableDbContext
    {
        public SakilaContext(DbContextOptions<SakilaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SakilaContext).Assembly);
        }
        public DbSet<Actor> actor { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<staff> staff { get; set; }
        public DbSet<Film> film { get; set; }
        public DbSet<refresh_token> refresh_token { get; set; }
    }
}
