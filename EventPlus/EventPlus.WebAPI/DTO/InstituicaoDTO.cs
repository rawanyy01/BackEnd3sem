using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "O titulo do tipo de evento é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "O Endereço do tipo de evento é obrigatorio!")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "O Cnpj do tipo de evento é obrigatorio!")]
        public string? Cnpj { get; set; }
    }
}