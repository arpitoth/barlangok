using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlangok.Data;
using Barlangok.Models;

namespace Barlangok.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Barlangok.Data.BarlangDbContext _context;

        public DeleteModel(Barlangok.Data.BarlangDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BarlangModel BarlangModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangmodel = await _context.Barlangok.FirstOrDefaultAsync(m => m.ID == id);

            if (barlangmodel == null)
            {
                return NotFound();
            }
            else
            {
                BarlangModel = barlangmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangmodel = await _context.Barlangok.FindAsync(id);
            if (barlangmodel != null)
            {
                BarlangModel = barlangmodel;
                _context.Barlangok.Remove(BarlangModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
