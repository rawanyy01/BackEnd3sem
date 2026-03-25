using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "O Nome é obrigatório!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A Imagem é obrigatoria!")]
    public string? Imagem { get; set; }

    [Required(ErrorMessage = "O Identificador é obrigatorio!")]
    public string? Identificador { get; set; }

    [Required(ErrorMessage = "A Forma de Contato é obrigatoria!")]
    public string? FormaContato { get; set; }

    [Required(ErrorMessage = "O Tipo de contato associado é obrigatorio!")]
    public string? TipoContadoAssociado { get; set; }


}
