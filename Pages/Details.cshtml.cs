using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestesDePerformance1.Models;
using TestesDePerformance1.Services;

namespace TestesDePerformance1.Pages
{
    public class DetailsModel : PageModel
    {
        private IGuitarService _service;
        public string NomeMarca { get; set; }

        public DetailsModel(IGuitarService service)
        {
            _service = service;
        }

        public Guitarra Guitarra { get; private set; }

        public IActionResult OnGet(int id)
        {
            Guitarra = _service.Get(id);
            if (Guitarra.MarcaId != null)
            {
                NomeMarca = _service.GetBrand(Guitarra.MarcaId.Value).DescricaoMarca;
            } else
            {
                NomeMarca = "Não disponível";
            }
            if (Guitarra == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
