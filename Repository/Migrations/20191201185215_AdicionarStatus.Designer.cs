﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191201185215_AdicionarStatus")]
    partial class AdicionarStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeDepartamento");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Domain.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfFuncionario");

                    b.Property<string>("NomeFuncionario");

                    b.Property<string>("SenhaFuncionario");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Domain.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoJob");

                    b.Property<DateTime>("DataEntregaJob");

                    b.Property<string>("DescricaoJob");

                    b.Property<int?>("DptoResponsavelDepartamentoId");

                    b.Property<int>("ProjetoId");

                    b.Property<string>("StatusJob");

                    b.Property<string>("TituloJob");

                    b.HasKey("JobId");

                    b.HasIndex("DptoResponsavelDepartamentoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Domain.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoProjeto");

                    b.Property<string>("DescricaoProjeto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NomeEmpresa")
                        .IsRequired();

                    b.Property<string>("NomeProjeto")
                        .IsRequired();

                    b.Property<string>("StatusProjeto");

                    b.HasKey("ProjetoId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoStatus");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Domain.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoTarefa");

                    b.Property<DateTime>("DataEntregaTarefa");

                    b.Property<string>("DescricaoTarefa");

                    b.Property<int>("JobId");

                    b.Property<int?>("ResponsavelFuncionarioId");

                    b.Property<string>("StatusTarefa");

                    b.Property<string>("TituloTarefa");

                    b.HasKey("TarefaId");

                    b.HasIndex("JobId");

                    b.HasIndex("ResponsavelFuncionarioId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Domain.Job", b =>
                {
                    b.HasOne("Domain.Departamento", "DptoResponsavel")
                        .WithMany()
                        .HasForeignKey("DptoResponsavelDepartamentoId");

                    b.HasOne("Domain.Projeto")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Tarefa", b =>
                {
                    b.HasOne("Domain.Job")
                        .WithMany("Tarefas")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Funcionario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelFuncionarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
