using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Models;

public partial class Fornecedor
{
    public int Id { get; set; }
    
    public string Cnpj { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    
    public virtual ICollection<Pacote> Pacotes { get; set; } = new List<Pacote>();

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fornecedor>()
            .HasOne(f => f.Endereco)
            .WithMany()
            .HasForeignKey(f => f.EnderecoId)
            .IsRequired();
    }
}
