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
    public class IndexModel : PageModel
    {
        private readonly Barlangok.Data.BarlangDbContext _context;

        public IndexModel(Barlangok.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IList<BarlangModel> BarlangModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BarlangModel = await _context.Barlangok.ToListAsync();
        }
    }
}
