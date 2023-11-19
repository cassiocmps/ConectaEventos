using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Endereco
{
    public int Id { get; set; }

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Complemento { get; set; }

    public string Bairro { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public virtual ICollection<Local> Locals { get; set; } = new List<Local>();

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
}
