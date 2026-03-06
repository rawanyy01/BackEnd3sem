using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("ComentarioEvento")]
public partial class ComentarioEvento
{
    [Key]
    public Guid IdComentarioEvento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataComentarioEvento { get; set; }

    [StringLength(1)]
    public string Descricao { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string Exibe { get; set; } = null!;

    public Guid? IdEvento { get; set; }

    public Guid? IdUsuario { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("ComentarioEventos")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
