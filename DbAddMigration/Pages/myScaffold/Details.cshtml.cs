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
    public class DetailsModel : PageModel
    {
        private readonly DbAddMigration.Data.DbAddMigrationContext _context;

        public DetailsModel(DbAddMigration.Data.DbAddMigrationContext context)
        {
            _context = context;
        }

        public Bil Bil { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bil.FirstOrDefaultAsync(m => m.Id == id);
            if (bil == null)
            {
                return NotFound();
            }
            else
            {
                Bil = bil;
            }
            return Page();
        }
    }
}
