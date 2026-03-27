using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConnectPlus.Models;

public partial class TipoContato
{
    public Guid IdTipoContato { get; set; }

    public string Titulo { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
