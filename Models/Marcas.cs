using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TestesDePerformance1.Models
{
    public class Marcas
    {
        [Key]
        public int MarcaId { get; set; }
        public string DescricaoMarca { get; set;}

        public ICollection<Guitarra>? Guitarras { get; set; }
    }
}
