using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Data;

public partial class ConectaEventosContext : DbContext
{
    public ConectaEventosContext(DbContextOptions<ConectaEventosContext> options) : base(options) { }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Endereco> Enderecos { get; set; }
    public virtual DbSet<Evento> Eventos { get; set; }
    public virtual DbSet<EventoFuncionario> EventoFuncionarios { get; set; }
    public virtual DbSet<EventoProduto> EventoProdutos { get; set; }
    public virtual DbSet<Fornecedor> Fornecedores { get; set; }
    public virtual DbSet<LocalFotos> LocalFotos { get; set; }
    public virtual DbSet<Funcionario> Funcionarios { get; set; }
    public virtual DbSet<Local> Locais { get; set; }
    public virtual DbSet<Pacote> Pacotes { get; set; }
    public virtual DbSet<Produto> Produtos { get; set; }
    public virtual DbSet<PacoteProduto> PacoteProdutos { get; set; }
    public virtual DbSet<Tema> Temas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fornecedor>()
            .HasMany(f => f.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId);

        modelBuilder.Entity<Fornecedor>()
            .HasMany(f => f.Pacotes)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId);

        modelBuilder.Entity<PacoteProduto>()
            .HasKey(pp => new { pp.IdPacote, pp.IdProduto });

        modelBuilder.Entity<PacoteProduto>()
            .HasOne(pp => pp.Pacote)
            .WithMany(p => p.PacoteProdutos)
            .HasForeignKey(pp => pp.IdPacote);

        modelBuilder.Entity<PacoteProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany()
            .HasForeignKey(pp => pp.IdProduto);

        modelBuilder.Entity<Pacote>()
            .HasMany(p => p.PacoteProdutos)
            .WithOne(pp => pp.Pacote)
            .HasForeignKey(pp => pp.IdPacote);

        modelBuilder.Entity<Pacote>()
            .HasOne(p => p.Fornecedor)
            .WithMany()
            .HasForeignKey(p => p.FornecedorId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Cliente)
            .WithMany()
            .HasForeignKey(e => e.ClienteId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Local)
            .WithMany()
            .HasForeignKey(e => e.LocalId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Pacote)
            .WithMany()
            .HasForeignKey(e => e.PacoteId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Tema)
            .WithMany()
            .HasForeignKey(e => e.TemaId);

        modelBuilder.Entity<EventoFuncionario>()
            .HasKey(ef => new { ef.EventoId, ef.FuncionarioId });

        modelBuilder.Entity<EventoFuncionario>()
            .HasOne(ef => ef.Evento)
            .WithMany(e => e.EventoFuncionarios)
            .HasForeignKey(ef => ef.EventoId);

        modelBuilder.Entity<EventoProduto>()
            .HasKey(ef => new { ef.EventoId, ef.ProdutoId });

        modelBuilder.Entity<EventoProduto>()
            .HasOne(ep => ep.Evento)
            .WithMany(e => e.EventoProdutos)
            .HasForeignKey(ep => ep.EventoId);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Endereco)
            .WithMany()
            .HasForeignKey(c => c.EnderecoId)
            .IsRequired();

        modelBuilder.Entity<Fornecedor>()
            .HasOne(f => f.Endereco)
            .WithMany()
            .HasForeignKey(f => f.EnderecoId)
            .IsRequired();

        modelBuilder.Entity<Funcionario>()
            .HasOne(f => f.Endereco)
            .WithMany()
            .HasForeignKey(f => f.EnderecoId)
            .IsRequired();

        modelBuilder.Entity<LocalFotos>()
            .HasOne(lf => lf.Local)
            .WithMany(l => l.Fotos)
            .HasForeignKey(lf => lf.LocalId)
            .IsRequired();

        modelBuilder.Entity<Local>()
            .HasOne(l => l.Endereco)
            .WithMany()
            .HasForeignKey(l => l.EnderecoId)
            .IsRequired();

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Fornecedor)
            .WithMany(f => f.Produtos)
            .HasForeignKey(p => p.FornecedorId)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
