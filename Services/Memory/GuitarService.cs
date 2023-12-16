using TestesDePerformance1.Models;

namespace TestesDePerformance1.Services.Memory
{
    public class GuitarService : IGuitarService
    {
        public GuitarService()
        {
            LoadInitialList();
        }

        private IList<Guitarra> _guitarras;

        private void LoadInitialList()
        {
            _guitarras = new List<Guitarra>
            {
                new Guitarra
                {
                    Id = 1,
                    Nome = "Kiko SP3",
                    Descricao = "A KikoSP3 é uma incrível guitarra Signature do Guitarrista KIKO LOUREIRO, Conhecido por tocar na banda Angra e Megadeth.",
                    ImagemUri = "/images/Guitarras/kikosp3.png",
                    Preco = 999.00,
                    DataCadastro = DateTime.Now
                },
            };
        }

        public IList<Guitarra> GetAll() => _guitarras;

        public Guitarra Get(int id) => GetAll().SingleOrDefault(item => item.Id == id);

        public void Include(Guitarra guitarra)
        {
            var nextId = _guitarras.Max(item => item.Id) + 1;
            guitarra.Id = nextId;
            _guitarras.Add(guitarra);
        }

        public void Update(Guitarra guitarra)
        {
            var guitarraFound = _guitarras.SingleOrDefault(item => item.Id == guitarra.Id);
            guitarraFound.Nome = guitarra.Nome;
            guitarraFound.Descricao = guitarra.Descricao;
            guitarraFound.Preco = guitarra.Preco;
            guitarraFound.DataCadastro = guitarra.DataCadastro;
            guitarraFound.ImagemUri = guitarra.ImagemUri;
        }

        public void Delete(int id)
        {
            var guitarraFound = Get(id);
            _guitarras.Remove(guitarraFound);
        }

        public IList<Marcas> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public Marcas GetBrand()
        {
            throw new NotImplementedException();
        }

        public Marcas GetBrand(int id)
        {
            throw new NotImplementedException();
        }
    }
}
