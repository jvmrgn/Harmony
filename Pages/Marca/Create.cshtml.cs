using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestesDePerformance1.Data;
using TestesDePerformance1.Models;

namespace TestesDePerformance1.Pages.Marca
{
    public class CreateModel : PageModel
    {
        private readonly TestesDePerformance1.Data.LojaDeGuitarraDbContext _context;

        public CreateModel(TestesDePerformance1.Data.LojaDeGuitarraDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Marcas Marcas { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Marcas == null || Marcas == null)
            {
                return Page();
            }

            _context.Marcas.Add(Marcas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
