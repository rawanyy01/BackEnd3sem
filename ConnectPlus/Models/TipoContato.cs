using System;
using System.Collections.Generic;

namespace ConnectPlus.Models;

public partial class TipoContato
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
