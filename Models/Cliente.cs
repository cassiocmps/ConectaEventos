using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Cpf { get; set; } = null!;

    public int PessoaId { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual Pessoa Pessoa { get; set; } = null!;
}
