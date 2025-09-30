using Barlangok.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Barlangok.Pages
{
    public class OsszesitoModel : PageModel
    {
        private readonly BarlangDbContext _context;

        public OsszesitoModel(BarlangDbContext context)
        {
            _context = context;
        }

        public List<TelepulesOsszesito> TelepulesOsszesites { get; set; } = new();

        public void OnGet()
        {
            TelepulesOsszesites = _context.Barlangok
                .GroupBy(b => b.Telepules)
                .Select(g => new TelepulesOsszesito
                {
                    Telepules = g.Key,
                    BarlangokSzama = g.Count()
                })
                .OrderByDescending(t => t.BarlangokSzama)
                .ToList();
        }

        public class TelepulesOsszesito
        {
            public string Telepules { get; set; }
            public int BarlangokSzama { get; set; }
        }
    }
}
