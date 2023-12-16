using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestesDePerformance1.Data;
using TestesDePerformance1.Models;

namespace TestesDePerformance1.Pages.Marca
{
    public class DetailsModel : PageModel
    {
        private readonly TestesDePerformance1.Data.LojaDeGuitarraDbContext _context;

        public DetailsModel(TestesDePerformance1.Data.LojaDeGuitarraDbContext context)
        {
            _context = context;
        }

      public Marcas Marcas { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcas = await _context.Marcas.FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marcas == null)
            {
                return NotFound();
            }
            else 
            {
                Marcas = marcas;
            }
            return Page();
        }
    }
}
