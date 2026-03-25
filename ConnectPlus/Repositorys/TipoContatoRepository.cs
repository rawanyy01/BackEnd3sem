using ConnectPlus.Data;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repository;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly AppDbContext _context;


    public TipoContatoRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<TipoContato> Listar()
    {

        return _context.TipoContatos.ToList();
    }

    public TipoContato BuscarPorId(Guid id)
    {

        return _context.TipoContatos.Find(id)!;
    }

    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

    public void Atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(id);

        if (tipoContatoBuscado != null)
        {

            _context.TipoContatos.Update(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }

    public void Deletar(Guid id)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(id);

        if (tipoContatoBuscado != null)
        {
            _context.TipoContatos.Remove(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }

    List<Contato> ITipoContatoRepository.Listar()
    {
        throw new NotImplementedException();
    }
}