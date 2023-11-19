using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Pacote
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int? TemaId { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<PacoteHasProduto> PacoteHasProdutos { get; set; } = new List<PacoteHasProduto>();

    public virtual Tema? Tema { get; set; }

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
