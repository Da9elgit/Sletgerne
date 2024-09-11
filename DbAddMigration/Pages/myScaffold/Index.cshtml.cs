using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DbAddMigration.Data;
using DbAddMigration.Models;

namespace DbAddMigration.Pages.myScaffold
{
    public class IndexModel : PageModel
    {
        private readonly DbAddMigration.Data.DbAddMigrationContext _context;

        public IndexModel(DbAddMigration.Data.DbAddMigrationContext context)
        {
            _context = context;
        }

        public IList<Bil> Bil { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bil = await _context.Bil.ToListAsync();
        }
    }
}
