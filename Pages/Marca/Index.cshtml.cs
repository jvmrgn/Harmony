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
    public class IndexModel : PageModel
    {
        private readonly TestesDePerformance1.Data.LojaDeGuitarraDbContext _context;

        public IndexModel(TestesDePerformance1.Data.LojaDeGuitarraDbContext context)
        {
            _context = context;
        }

        public IList<Marcas> Marcas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Marcas != null)
            {
                Marcas = await _context.Marcas.ToListAsync();
            }
        }
    }
}
