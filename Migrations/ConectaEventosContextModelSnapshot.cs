﻿// <auto-generated />
using System;
using ConectaEventos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConectaEventos.Migrations
{
    [DbContext(typeof(ConectaEventosContext))]
    partial class ConectaEventosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConectaEventos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ConectaEventos.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("LocalId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PacoteId")
                        .HasColumnType("integer");

                    b.Property<int?>("TemaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LocalId");

                    b.HasIndex("PacoteId");

                    b.HasIndex("TemaId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ConectaEventos.Models.EventoFuncionario", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("integer");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("integer");

                    b.HasKey("EventoId", "FuncionarioId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("EventoFuncionarios");
                });

            modelBuilder.Entity("ConectaEventos.Models.EventoProduto", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.HasKey("EventoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("EventoProdutos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ConectaEventos.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Admissao")
                        .HasColumnType("date");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ctps")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salario")
                        .HasColumnType("numeric");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ConectaEventos.Models.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("ConectaEventos.Models.LocalFoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LocalId")
                        .HasColumnType("integer");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("LocalFotos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Pacote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TemaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("TemaId");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("ConectaEventos.Models.PacoteProduto", b =>
                {
                    b.Property<int>("IdPacote")
                        .HasColumnType("integer");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("IdPacote", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("PacoteProdutos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Tema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Decoracao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("ConectaEventos.Models.Cliente", b =>
                {
                    b.HasOne("ConectaEventos.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ConectaEventos.Models.Evento", b =>
                {
                    b.HasOne("ConectaEventos.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConectaEventos.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConectaEventos.Models.Pacote", "Pacote")
                        .WithMany()
                        .HasForeignKey("PacoteId");

                    b.HasOne("ConectaEventos.Models.Tema", "Tema")
                        .WithMany()
                        .HasForeignKey("TemaId");

                    b.Navigation("Cliente");

                    b.Navigation("Local");

                    b.Navigation("Pacote");

                    b.Navigation("Tema");
                });

            modelBuilder.Entity("ConectaEventos.Models.EventoFuncionario", b =>
                {
                    b.HasOne("ConectaEventos.Models.Evento", "Evento")
                        .WithMany("EventoFuncionarios")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConectaEventos.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("ConectaEventos.Models.EventoProduto", b =>
                {
                    b.HasOne("ConectaEventos.Models.Evento", "Evento")
                        .WithMany("EventoProdutos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConectaEventos.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ConectaEventos.Models.Fornecedor", b =>
                {
                    b.HasOne("ConectaEventos.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ConectaEventos.Models.Funcionario", b =>
                {
                    b.HasOne("ConectaEventos.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ConectaEventos.Models.Local", b =>
                {
                    b.HasOne("ConectaEventos.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ConectaEventos.Models.LocalFoto", b =>
                {
                    b.HasOne("ConectaEventos.Models.Local", "Local")
                        .WithMany("Fotos")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");
                });

            modelBuilder.Entity("ConectaEventos.Models.Pacote", b =>
                {
                    b.HasOne("ConectaEventos.Models.Fornecedor", "Fornecedor")
                        .WithMany("Pacotes")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConectaEventos.Models.Tema", "Tema")
                        .WithMany()
                        .HasForeignKey("TemaId");

                    b.Navigation("Fornecedor");

                    b.Navigation("Tema");
                });

            modelBuilder.Entity("ConectaEventos.Models.PacoteProduto", b =>
                {
                    b.HasOne("ConectaEventos.Models.Pacote", "Pacote")
                        .WithMany("PacoteProdutos")
                        .HasForeignKey("IdPacote")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConectaEventos.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacote");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ConectaEventos.Models.Produto", b =>
                {
                    b.HasOne("ConectaEventos.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ConectaEventos.Models.Evento", b =>
                {
                    b.Navigation("EventoFuncionarios");

                    b.Navigation("EventoProdutos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Fornecedor", b =>
                {
                    b.Navigation("Pacotes");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Local", b =>
                {
                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("ConectaEventos.Models.Pacote", b =>
                {
                    b.Navigation("PacoteProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
