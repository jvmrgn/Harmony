using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestesDePerformance1.Models;
using TestesDePerformance1.Services;

namespace TestesDePerformance1.Pages
{
    public class IndexModel : PageModel
    {
        private IGuitarService _service;

        public IndexModel(IGuitarService service)
        {
            _service = service;
        }
        
        public IList<Guitarra> ListGuitar { get; private set; }
        public void OnGet()
        { 
            ViewData["Title"] = "Home Page";
            ListGuitar = _service.GetAll();
    }
}
}
