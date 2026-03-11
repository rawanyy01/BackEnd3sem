using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repository;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _Context;
    public TipoEventoRepository (EventContext context)
    {
        _Context = context; 
    }

    /// <summary>
    /// Atualiza um tipo de event usando o rastreamento automatico
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tipoEvento"></param>
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _Context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um tipo de event por Id
    /// </summary>
    /// <param name="id">Id to tipo evento a ser buscado</param>
    /// <returns></returns>
    public TipoEvento BuscarPorId(Guid id)
    {
        return _Context.TipoEventos.Find(id)!;
    }

    /// <summary>
    /// Cadastrar um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _Context.TipoEventos.Add(tipoEvento);
        _Context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _Context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            _Context.TipoEventos.Remove(tipoEventoBuscado);
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de eventos cadastrados
    /// </summary>
    /// <returns>Uma lista dr tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _Context.TipoEventos
            .OrderBy(TipoEvento => TipoEvento.Titulo)
            .ToList();
    }
}
