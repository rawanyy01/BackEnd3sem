using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "O Nome é obrigatório!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A Imagem é obrigatoria!")]
    public IFormFile Imagem { get; set; }

    [Required(ErrorMessage = "A Forma de Contato é obrigatoria!")]
    public string? DadosContato { get; set; }

    public Guid IdTipoContato { get; set; }


}
