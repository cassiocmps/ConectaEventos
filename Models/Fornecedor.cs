using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Fornecedor
{
    public int Id { get; set; }

    public string Cnpj { get; set; } = null!;

    public int PessoaId { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
