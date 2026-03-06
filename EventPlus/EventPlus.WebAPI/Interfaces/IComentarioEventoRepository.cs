using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IComentarioEventoRepository
{
    void cadastrar(ComentarioEvento comentarioEvento);
    void Deletar(Guid IdComentarioEvento);
    List<ComentarioEvento> List(Guid IdEvento);
    ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdComentarioEvento);
    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}
