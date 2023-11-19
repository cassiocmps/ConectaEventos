using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Local
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public int EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<FotosLocal> FotosLocals { get; set; } = new List<FotosLocal>();
}
