using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class FotosLocal
{
    public int Id { get; set; }

    public string NomeArquivo { get; set; } = null!;

    public int LocalId { get; set; }

    public virtual Local Local { get; set; } = null!;
}
