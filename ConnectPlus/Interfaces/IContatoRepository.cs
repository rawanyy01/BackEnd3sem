using ConnectPlus.Models;

namespace ConnectPlus.Interfaces
{
    public interface IContatoRepository
    {
        void Cadastrar(Contato contato);
        void Deletar(Guid id);
        List<Contato> Listar();
        Contato BuscarPorId(Guid id);
        void Atualizar(Guid id, Contato contato);
    }
}
