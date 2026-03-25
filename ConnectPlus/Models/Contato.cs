using System;
using System.Collections.Generic;

namespace ConnectPlus.Models;

public partial class Contato
{
    public static object Titulo { get; internal set; }
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string FormaContato { get; set; } = null!;

    public string? Imagem { get; set; }

    public int TipoContatoId { get; set; }

    public virtual TipoContato TipoContato { get; set; } = null!;
    public object IdTipoContatoNavigation { get; internal set; }
    public object IdTipoContato { get; internal set; }
    public Guid IdContato { get; internal set; }
}
