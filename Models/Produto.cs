using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int FornecedorId { get; set; }
    [JsonIgnore]
    public virtual Fornecedor Fornecedor { get; set; } = null!;

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Fornecedor)
            .WithMany(f => f.Produtos)
            .HasForeignKey(p => p.FornecedorId)
            .IsRequired();
    }
}
