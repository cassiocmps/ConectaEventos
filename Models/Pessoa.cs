using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Pessoa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int EnderecoId { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<Fornecedor> Fornecedors { get; set; } = new List<Fornecedor>();

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Funicionario> Funicionarios { get; set; } = new List<Funicionario>();
}
