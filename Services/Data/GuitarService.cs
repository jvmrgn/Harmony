using TestesDePerformance1.Data;
using TestesDePerformance1.Models;

namespace TestesDePerformance1.Services.Data;

public class GuitarService : IGuitarService
{
    private LojaDeGuitarraDbContext _context;
    public GuitarService(LojaDeGuitarraDbContext context)
    {
        _context = context;
    }

    public void Delete(int id)
    {
        var instrumento = Get(id);
        _context.Guitarra.Remove(instrumento);
        _context.SaveChanges();
    }

    public Guitarra Get(int id)
    {
        return _context.Guitarra.SingleOrDefault(item => item.Id == id);
    }

    public IList<Guitarra> GetAll()
    {
        return _context.Guitarra.ToList();
    }

    public void Include(Guitarra guitarra)
    {
        _context.Guitarra.Add(guitarra);
        _context.SaveChanges();
    }

    public void Update(Guitarra guitarra)
    {
        var instrumento = Get(guitarra.Id);
        instrumento.Nome = guitarra.Nome;
        instrumento.Descricao = guitarra.Descricao;
        instrumento.Preco = guitarra.Preco;
        instrumento.Cordas = guitarra.Cordas;
        instrumento.ImagemUri = guitarra.ImagemUri;
        instrumento.EntregaExpressa = guitarra.EntregaExpressa;
        instrumento.DataCadastro = guitarra.DataCadastro;
        instrumento.MarcaId = guitarra.MarcaId;
        _context.SaveChanges();
    }

    public IList<Marcas> GetAllBrands()
        => _context.Marcas.ToList();

    public Marcas GetBrand(int id)
        => _context.Marcas.SingleOrDefault(item => item.MarcaId == id);
}

