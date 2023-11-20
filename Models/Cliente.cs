using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Models;

public class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Endereco)
            .WithMany()
            .HasForeignKey(c => c.EnderecoId)
            .IsRequired();
    }
}
