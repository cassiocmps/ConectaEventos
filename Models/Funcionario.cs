﻿using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Models;

public class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Ctps { get; set; } = null!;

    public DateOnly Admissao { get; set; }

    public string Cargo { get; set; } = null!;

    public decimal Salario { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>()
            .HasOne(f => f.Endereco)
            .WithMany()
            .HasForeignKey(f => f.EnderecoId)
            .IsRequired();
    }
}
