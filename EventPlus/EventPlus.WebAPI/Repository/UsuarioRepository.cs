using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;
    private bool confere;

    public  UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuario pelo Email e valoida o Hash da senha
    /// </summary>
    /// <param name="Email">Email do usuario</param>
    /// <param name="Senha">Senha do usuario</param>
    /// <returns>Usuario Buscado e Valido</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        var usuarioBuscado = _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.Email == Email);

        if (usuarioBuscado != null)
        {
            Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
    }


    /// <summary>
    /// Buscar um usuario pelo Id, incluindo os dados do seu tipo usuario
    /// </summary>
    /// <param name="IdUsuario">Id do usuario a ser buscado</param>
    /// <returns>Usuario buscado</returns>
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.IdTipoUsuario == IdUsuario)!;

       
    }

    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada 
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    
}
