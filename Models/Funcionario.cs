using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Ctps { get; set; } = null!;

    public DateOnly Admissao { get; set; }

    public string Cargo { get; set; } = null!;

    public decimal Salario { get; set; }

    public int PessoaId { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
