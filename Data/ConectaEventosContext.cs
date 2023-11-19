using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Data;

public partial class ConectaEventosContext : DbContext
{
    public ConectaEventosContext()
    {
    }

    public ConectaEventosContext(DbContextOptions<ConectaEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<EventoHasProduto> EventoHasProdutos { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<FotosLocal> FotosLocals { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Funicionario> Funicionarios { get; set; }

    public virtual DbSet<Local> Locals { get; set; }

    public virtual DbSet<Pacote> Pacotes { get; set; }

    public virtual DbSet<PacoteHasProduto> PacoteHasProdutos { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=isabelle.db.elephantsql.com;Port=5432;Database=palzcrlz;Username=palzcrlz;Password=Qjb7uO9CDhm5WdxQd2UhQdEtaBRjgXes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.PessoaId)
                .HasConstraintName("fk_cliente_pessoa");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("endereco_pkey");

            entity.ToTable("endereco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .HasColumnName("cidade");
            entity.Property(e => e.Complemento)
                .HasMaxLength(200)
                .HasColumnName("complemento");
            entity.Property(e => e.Estado)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.Numero)
                .HasMaxLength(5)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(200)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("evento_pkey");

            entity.ToTable("evento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.LocalId).HasColumnName("local_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .HasColumnName("nome");
            entity.Property(e => e.PacoteId).HasColumnName("pacote_id");
            entity.Property(e => e.TemaId).HasColumnName("tema_id");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(8, 2)
                .HasColumnName("valor_total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_evento_cliente");

            entity.HasOne(d => d.Local).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.LocalId)
                .HasConstraintName("fk_evento_local");

            entity.HasOne(d => d.Pacote).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.PacoteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_evento_pacote");

            entity.HasOne(d => d.Tema).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.TemaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_evento_tema");

            entity.HasMany(d => d.Funcionarios).WithMany(p => p.Eventos)
                .UsingEntity<Dictionary<string, object>>(
                    "EventoHasFuncionario",
                    r => r.HasOne<Funcionario>().WithMany()
                        .HasForeignKey("FuncionarioId")
                        .HasConstraintName("fk_evento_has_funcionario_funcionario"),
                    l => l.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoId")
                        .HasConstraintName("fk_evento_has_funcionario_evento"),
                    j =>
                    {
                        j.HasKey("EventoId", "FuncionarioId").HasName("evento_has_funcionario_pkey");
                        j.ToTable("evento_has_funcionario");
                        j.IndexerProperty<int>("EventoId").HasColumnName("evento_id");
                        j.IndexerProperty<int>("FuncionarioId").HasColumnName("funcionario_id");
                    });

            entity.HasMany(d => d.Servicos).WithMany(p => p.Eventos)
                .UsingEntity<Dictionary<string, object>>(
                    "EventoHasServico",
                    r => r.HasOne<Servico>().WithMany()
                        .HasForeignKey("ServicoId")
                        .HasConstraintName("fk_evento_has_servico_servico"),
                    l => l.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoId")
                        .HasConstraintName("fk_evento_has_servico_evento"),
                    j =>
                    {
                        j.HasKey("EventoId", "ServicoId").HasName("evento_has_servico_pkey");
                        j.ToTable("evento_has_servico");
                        j.IndexerProperty<int>("EventoId").HasColumnName("evento_id");
                        j.IndexerProperty<int>("ServicoId").HasColumnName("servico_id");
                    });
        });

        modelBuilder.Entity<EventoHasProduto>(entity =>
        {
            entity.HasKey(e => new { e.EventoId, e.ProdutoId }).HasName("evento_has_produto_pkey");

            entity.ToTable("evento_has_produto");

            entity.Property(e => e.EventoId).HasColumnName("evento_id");
            entity.Property(e => e.ProdutoId).HasColumnName("produto_id");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.Evento).WithMany(p => p.EventoHasProdutos)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("fk_evento_has_produto_evento");

            entity.HasOne(d => d.Produto).WithMany(p => p.EventoHasProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("fk_evento_has_produto_produto");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fornecedor_pkey");

            entity.ToTable("fornecedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Fornecedors)
                .HasForeignKey(d => d.PessoaId)
                .HasConstraintName("fk_fornecedor_pessoa");
        });

        modelBuilder.Entity<FotosLocal>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.LocalId }).HasName("fotos_local_pkey");

            entity.ToTable("fotos_local");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.LocalId).HasColumnName("local_id");
            entity.Property(e => e.NomeArquivo)
                .HasMaxLength(45)
                .HasColumnName("nome_arquivo");

            entity.HasOne(d => d.Local).WithMany(p => p.FotosLocals)
                .HasForeignKey(d => d.LocalId)
                .HasConstraintName("fk_fotos_local_local");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("funcionario_pkey");

            entity.ToTable("funcionario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Admissao).HasColumnName("admissao");
            entity.Property(e => e.Cargo)
                .HasMaxLength(45)
                .HasColumnName("cargo");
            entity.Property(e => e.Ctps)
                .HasMaxLength(12)
                .HasColumnName("ctps");
            entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");
            entity.Property(e => e.Salario)
                .HasPrecision(8, 2)
                .HasColumnName("salario");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.PessoaId)
                .HasConstraintName("fk_funicionario_pessoa");
        });

        modelBuilder.Entity<Funicionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("funicionario_pkey");

            entity.ToTable("funicionario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Admissao).HasColumnName("admissao");
            entity.Property(e => e.Cargo)
                .HasMaxLength(45)
                .HasColumnName("cargo");
            entity.Property(e => e.Ctps)
                .HasMaxLength(12)
                .HasColumnName("ctps");
            entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");
            entity.Property(e => e.Salario)
                .HasPrecision(8, 2)
                .HasColumnName("salario");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Funicionarios)
                .HasForeignKey(d => d.PessoaId)
                .HasConstraintName("fk_funicionario_pessoa");
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("local_pkey");

            entity.ToTable("local");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .HasColumnName("nome");

            entity.HasOne(d => d.Endereco).WithMany(p => p.Locals)
                .HasForeignKey(d => d.EnderecoId)
                .HasConstraintName("fk_local_endereco");
        });

        modelBuilder.Entity<Pacote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pacote_pkey");

            entity.ToTable("pacote");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.TemaId).HasColumnName("tema_id");
            entity.Property(e => e.Valor)
                .HasPrecision(8, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.Tema).WithMany(p => p.Pacotes)
                .HasForeignKey(d => d.TemaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_pacote_tema");

            entity.HasMany(d => d.Servicos).WithMany(p => p.Pacotes)
                .UsingEntity<Dictionary<string, object>>(
                    "PacoteHasServico",
                    r => r.HasOne<Servico>().WithMany()
                        .HasForeignKey("ServicoId")
                        .HasConstraintName("fk_pacote_has_servico_servico"),
                    l => l.HasOne<Pacote>().WithMany()
                        .HasForeignKey("PacoteId")
                        .HasConstraintName("fk_pacote_has_servico_pacote"),
                    j =>
                    {
                        j.HasKey("PacoteId", "ServicoId").HasName("pacote_has_servico_pkey");
                        j.ToTable("pacote_has_servico");
                        j.IndexerProperty<int>("PacoteId").HasColumnName("pacote_id");
                        j.IndexerProperty<int>("ServicoId").HasColumnName("servico_id");
                    });
        });

        modelBuilder.Entity<PacoteHasProduto>(entity =>
        {
            entity.HasKey(e => new { e.PacoteId, e.ProdutoId }).HasName("pacote_has_produto_pkey");

            entity.ToTable("pacote_has_produto");

            entity.Property(e => e.PacoteId).HasColumnName("pacote_id");
            entity.Property(e => e.ProdutoId).HasColumnName("produto_id");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.Pacote).WithMany(p => p.PacoteHasProdutos)
                .HasForeignKey(d => d.PacoteId)
                .HasConstraintName("fk_pacote_has_produto_pacote");

            entity.HasOne(d => d.Produto).WithMany(p => p.PacoteHasProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("fk_pacote_has_produto_produto");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pagamento_pkey");

            entity.ToTable("pagamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodAutenticacao).HasColumnName("cod_autenticacao");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.EventoId).HasColumnName("evento_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasPrecision(8, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.Evento).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("fk_pagamento_evento");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pessoa_pkey");

            entity.ToTable("pessoa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Sobrenome)
                .HasMaxLength(45)
                .HasColumnName("sobrenome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(12)
                .HasColumnName("telefone");

            entity.HasOne(d => d.Endereco).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.EnderecoId)
                .HasConstraintName("fk_pessoa_endereco");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("produto_pkey");

            entity.ToTable("produto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.FornecedorId).HasColumnName("fornecedor_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Valor)
                .HasPrecision(8, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.FornecedorId)
                .HasConstraintName("fk_produto_fornecedor");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servico_pkey");

            entity.ToTable("servico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.FornecedorId).HasColumnName("fornecedor_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Valor)
                .HasPrecision(8, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.FornecedorId)
                .HasConstraintName("fk_servico_fornecedor");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tema_pkey");

            entity.ToTable("tema");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Decoracao)
                .HasMaxLength(100)
                .HasColumnName("decoracao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Valor)
                .HasPrecision(8, 2)
                .HasColumnName("valor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
