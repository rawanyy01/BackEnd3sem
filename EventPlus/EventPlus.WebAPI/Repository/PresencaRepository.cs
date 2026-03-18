using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repository;

public class PresencaRepository : IPresencaRepository
{
    public readonly EventContext _context;
    public PresencaRepository (EventContext context)
    {
        _context = context;
    }


    public void Atualizar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Metodo que busca uma presenca por id
    /// </summary>
    /// <param name="id">id da presenca a ser buscada</param>
    /// <returns>presenca buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
                .ThenInclude(e => e!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == id)!;
    }

    public void Deletar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

    public void Cadastrar(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(Presenca => Presenca).ToList();
    }


    /// <summary>
    /// Metodo q lista a presenca de um usuario especifico
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>lista de presenca de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
                .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();
    }

    public void Inscrever(Presenca presenca)
    {
        throw new NotImplementedException();
    }
}
