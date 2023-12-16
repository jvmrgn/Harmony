using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestesDePerformance1.Models;
using TestesDePerformance1.Services;
using NToastNotify;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TestesDePerformance1.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IGuitarService _service;
        private readonly IToastNotification _toastNotification;

        public CreateModel(IGuitarService service, IToastNotification toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Guitarra Guitar { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Include(Guitar);

            _toastNotification.AddSuccessToastMessage("Guitarra incluída com sucesso!");

            return RedirectToPage("/Index");
        }

        public SelectList BrandOptions { get; set; }
        public void OnGet()
        {
            BrandOptions = new SelectList(_service.GetAllBrands(), nameof(Marcas.MarcaId), nameof(Marcas.DescricaoMarca));
        }
    }
}
