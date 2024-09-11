using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbAddMigration.Data;
using DbAddMigration.Models;

namespace DbAddMigration.Pages.myScaffold
{
    public class EditModel : PageModel
    {
        private readonly DbAddMigration.Data.DbAddMigrationContext _context;

        public EditModel(DbAddMigration.Data.DbAddMigrationContext context)
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

            var bil =  await _context.Bil.FirstOrDefaultAsync(m => m.Id == id);
            if (bil == null)
            {
                return NotFound();
            }
            Bil = bil;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilExists(Bil.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BilExists(int id)
        {
            return _context.Bil.Any(e => e.Id == id);
        }
    }
}
