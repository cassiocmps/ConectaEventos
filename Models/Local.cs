using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class Local
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<LocalFotos> Fotos { get; set; } = new List<LocalFotos>();
}
