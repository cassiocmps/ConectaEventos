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
    public virtual DbSet<Funcionario> Funcionarios { get; set; }
    public virtual DbSet<LocalFoto> LocalFotos { get; set; }
    public virtual DbSet<Local> Locais { get; set; }
    public virtual DbSet<Pacote> Pacotes { get; set; }
    public virtual DbSet<Produto> Produtos { get; set; }
    public virtual DbSet<PacoteProduto> PacoteProdutos { get; set; }
    public virtual DbSet<Tema> Temas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Cliente.ConfigureModelCreating(modelBuilder);
        Evento.ConfigureModelCreating(modelBuilder);
        EventoFuncionario.ConfigureModelCreating(modelBuilder);
        EventoProduto.ConfigureModelCreating(modelBuilder);
        Fornecedor.ConfigureModelCreating(modelBuilder);
        Funcionario.ConfigureModelCreating(modelBuilder);
        Local.ConfigureModelCreating(modelBuilder);
        LocalFoto.ConfigureModelCreating(modelBuilder);
        Pacote.ConfigureModelCreating(modelBuilder);
        Produto.ConfigureModelCreating(modelBuilder);
        PacoteProduto.ConfigureModelCreating(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

}
