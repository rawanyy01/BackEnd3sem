using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    void BuscarPorId(Guid Usuario);

    Usuario BuscarPorEmailESenha(string Email, string Senha);
}
