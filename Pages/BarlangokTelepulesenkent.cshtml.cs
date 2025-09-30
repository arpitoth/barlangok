using Barlangok.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Barlangok.Pages
{
    public class BarlangokTelepulesenkentModel : PageModel
    {
        private readonly Barlangok.Data.BarlangDbContext _context;

        public BarlangokTelepulesenkentModel(Barlangok.Data.BarlangDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string KijeloltTelepules { get; set; }

        public List<SelectListItem> Telepulesek { get; set; } = new List<SelectListItem>();
        public IList<BarlangModel> Barlangok { get; set; } = new List<BarlangModel>();

        public void OnGet()
        {
            Telepulesek = _context.Barlangok
                                  .Select(x => x.Telepules)
                                  .Distinct()
                                  .OrderBy(t => t)
                                  .Select(t => new SelectListItem
                                  {
                                      Value = t,
                                      Text = t
                                  }).ToList();

            if (!string.IsNullOrEmpty(KijeloltTelepules))
            {
                Barlangok = _context.Barlangok
                                    .Where(x => x.Telepules == KijeloltTelepules)
                                    .ToList();
            }
        }
    }
}
