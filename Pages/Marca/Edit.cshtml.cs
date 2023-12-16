using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesDePerformance1.Data;
using TestesDePerformance1.Models;

namespace TestesDePerformance1.Pages.Marca
{
    public class EditModel : PageModel
    {
        private readonly TestesDePerformance1.Data.LojaDeGuitarraDbContext _context;

        public EditModel(TestesDePerformance1.Data.LojaDeGuitarraDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Marcas Marcas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcas =  await _context.Marcas.FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marcas == null)
            {
                return NotFound();
            }
            Marcas = marcas;
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

            _context.Attach(Marcas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcasExists(Marcas.MarcaId))
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

        private bool MarcasExists(int id)
        {
          return (_context.Marcas?.Any(e => e.MarcaId == id)).GetValueOrDefault();
        }
    }
}
