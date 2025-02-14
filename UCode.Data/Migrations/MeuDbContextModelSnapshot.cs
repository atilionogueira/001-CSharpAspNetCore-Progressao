﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UCode.Data.Context;

#nullable disable

namespace UCode.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    partial class MeuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UCode.Business.Models.Atividade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Detalhes")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<decimal>("Pontos")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CampoId");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("UCode.Business.Models.Campo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Campos");
                });

            modelBuilder.Entity("UCode.Business.Models.Campus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Campuss");
                });

            modelBuilder.Entity("UCode.Business.Models.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("UCode.Business.Models.Classe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("UCode.Business.Models.Comprovante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Arquivo")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("AtividadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProgressaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("ProgressaoId");

                    b.ToTable("Comprovantes");
                });

            modelBuilder.Entity("UCode.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CampusId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("UCode.Business.Models.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Uf")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("UCode.Business.Models.Progressao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AtividadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClasseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("ClasseId");

                    b.ToTable("Progressaos");
                });

            modelBuilder.Entity("UCode.Business.Models.Servidor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Siape")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Servidors");
                });

            modelBuilder.Entity("UCode.Business.Models.Situacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Detalhes")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("MovimentadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovimentadoPorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Situacaos");
                });

            modelBuilder.Entity("UCode.Business.Models.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Statuss");
                });

            modelBuilder.Entity("UCode.Business.Models.Validacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComprovanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComprovanteId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Justificativa")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidadoEm")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComprovanteId")
                        .IsUnique();

                    b.HasIndex("ComprovanteId1");

                    b.ToTable("Validacaos");
                });

            modelBuilder.Entity("UCode.Business.Models.Atividade", b =>
                {
                    b.HasOne("UCode.Business.Models.Campo", "Campo")
                        .WithMany("Atividades")
                        .HasForeignKey("CampoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campo");
                });

            modelBuilder.Entity("UCode.Business.Models.Cidade", b =>
                {
                    b.HasOne("UCode.Business.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("UCode.Business.Models.Comprovante", b =>
                {
                    b.HasOne("UCode.Business.Models.Atividade", "Atividade")
                        .WithMany("Comprovantes")
                        .HasForeignKey("AtividadeId")
                        .IsRequired();

                    b.HasOne("UCode.Business.Models.Progressao", "Progressao")
                        .WithMany()
                        .HasForeignKey("ProgressaoId")
                        .IsRequired();

                    b.Navigation("Atividade");

                    b.Navigation("Progressao");
                });

            modelBuilder.Entity("UCode.Business.Models.Endereco", b =>
                {
                    b.HasOne("UCode.Business.Models.Campus", "Campus")
                        .WithOne("Endereco")
                        .HasForeignKey("UCode.Business.Models.Endereco", "CampusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("UCode.Business.Models.Progressao", b =>
                {
                    b.HasOne("UCode.Business.Models.Atividade", null)
                        .WithMany("Progressaos")
                        .HasForeignKey("AtividadeId");

                    b.HasOne("UCode.Business.Models.Classe", "Classe")
                        .WithMany("Progressaos")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("UCode.Business.Models.Servidor", b =>
                {
                    b.HasOne("UCode.Business.Models.Campus", "Campus")
                        .WithMany("Servidors")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("UCode.Business.Models.Situacao", b =>
                {
                    b.HasOne("UCode.Business.Models.Status", "Status")
                        .WithMany("Situacaos")
                        .HasForeignKey("StatusId")
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("UCode.Business.Models.Validacao", b =>
                {
                    b.HasOne("UCode.Business.Models.Comprovante", "Comprovante")
                        .WithOne("Validacao")
                        .HasForeignKey("UCode.Business.Models.Validacao", "ComprovanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCode.Business.Models.Comprovante", null)
                        .WithMany("Valicacaos")
                        .HasForeignKey("ComprovanteId1");

                    b.Navigation("Comprovante");
                });

            modelBuilder.Entity("UCode.Business.Models.Atividade", b =>
                {
                    b.Navigation("Comprovantes");

                    b.Navigation("Progressaos");
                });

            modelBuilder.Entity("UCode.Business.Models.Campo", b =>
                {
                    b.Navigation("Atividades");
                });

            modelBuilder.Entity("UCode.Business.Models.Campus", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Servidors");
                });

            modelBuilder.Entity("UCode.Business.Models.Classe", b =>
                {
                    b.Navigation("Progressaos");
                });

            modelBuilder.Entity("UCode.Business.Models.Comprovante", b =>
                {
                    b.Navigation("Valicacaos");

                    b.Navigation("Validacao");
                });

            modelBuilder.Entity("UCode.Business.Models.Status", b =>
                {
                    b.Navigation("Situacaos");
                });
#pragma warning restore 612, 618
        }
    }
}
