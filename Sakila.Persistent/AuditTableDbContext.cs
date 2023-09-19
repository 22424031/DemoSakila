using Microsoft.EntityFrameworkCore;
using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent
{
    public abstract class AuditTableDbContext : DbContext
    {
        public AuditTableDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual async Task<int> SaveChangeAsync(string username = "system")
        {
            int flatsave = 0;
            foreach(var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                if (username == null) username = "system";
               // entry.Entity.last_updateBy = username;
                entry.Entity.last_update = DateTime.Now;
                flatsave = await base.SaveChangesAsync();
                entry.State = EntityState.Detached;
                return flatsave;
            }
            flatsave = await base.SaveChangesAsync();
            return flatsave;
        }
    }
}
