
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using TestesDePerformance1.Models;
using TestesDePerformance1.Services;

namespace TestesDePerformance1.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IGuitarService _service;
        private readonly IToastNotification _toastNotification;

        public EditModel(IGuitarService service, IToastNotification toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Guitarra Guitar { get; set; }
        public SelectList BrandOptions { get; set; }


        public IActionResult OnGet(int id)
        {
            Guitar = _service.Get(id);
            BrandOptions = new SelectList(_service.GetAllBrands(), nameof(Marcas.MarcaId), nameof(Marcas.DescricaoMarca));

            if (Guitar == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Update(Guitar);

            _toastNotification.AddSuccessToastMessage("Guitarra alterada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            _service.Delete(Guitar.Id);

            _toastNotification.AddSuccessToastMessage("Guitarra excluída com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}
