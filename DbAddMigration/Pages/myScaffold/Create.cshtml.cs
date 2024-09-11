using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DbAddMigration.Data;
using DbAddMigration.Models;

namespace DbAddMigration.Pages.myScaffold
{
    public class CreateModel : PageModel
    {
        private readonly DbAddMigration.Data.DbAddMigrationContext _context;

        public CreateModel(DbAddMigration.Data.DbAddMigrationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bil Bil { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bil.Add(Bil);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
