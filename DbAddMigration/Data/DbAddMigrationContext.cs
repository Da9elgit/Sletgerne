using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DbAddMigration.Models;

namespace DbAddMigration.Data
{
    public class DbAddMigrationContext : DbContext
    {
        public DbAddMigrationContext (DbContextOptions<DbAddMigrationContext> options)
            : base(options)
        {
        }

        public DbSet<DbAddMigration.Models.Bil> Bil { get; set; } = default!;
    }
}
