using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class EventoDTO
    {
        [Required(ErrorMessage = "O titulo do tipo de evento é obrigatório!")]
        public string? NomeFantasia { get; set; }
    }
}