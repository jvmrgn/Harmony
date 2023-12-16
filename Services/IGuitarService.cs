using TestesDePerformance1.Models;

namespace TestesDePerformance1.Services
{
    public interface IGuitarService
    {
        IList<Guitarra> GetAll();
        Guitarra Get(int id);
        void Include(Guitarra guitarra);
        void Update(Guitarra guitarra);
        void Delete(int id);
        IList<Marcas> GetAllBrands();
        Marcas GetBrand(int id);
    }
}
