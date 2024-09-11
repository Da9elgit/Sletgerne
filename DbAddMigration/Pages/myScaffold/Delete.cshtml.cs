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
    public class DeleteModel : PageModel
    {
        private readonly DbAddMigration.Data.DbAddMigrationContext _context;

        public DeleteModel(DbAddMigration.Data.DbAddMigrationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bil.FindAsync(id);
            if (bil != null)
            {
                Bil = bil;
                _context.Bil.Remove(Bil);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
