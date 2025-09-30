using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Barlangok.Data;
using Barlangok.Models;

namespace Barlangok.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Barlangok.Data.BarlangDbContext _context;

        public CreateModel(Barlangok.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BarlangModel BarlangModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Barlangok.Add(BarlangModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
