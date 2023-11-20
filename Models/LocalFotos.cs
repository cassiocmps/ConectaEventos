using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class LocalFotos
{
    public int Id { get; set; }

    public string NomeArquivo { get; set; } = null!;

    [JsonIgnore]
    public virtual Local Local { get; set; } = null!;
    public int LocalId { get; set; }
}
