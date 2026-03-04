using System.ComponentModel.DataAnnotations;

namespace Filmes.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O Emal do úsuario é obrigatório!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A Senha do úsuario é obrigatório!")]
    public string? Senha { get; set; }
}
