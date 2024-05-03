﻿// <auto-generated />
using System;
using Fiap.Web.MVPSaude.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Web.MVPSaude.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240503230852_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.ConsultaModel", b =>
                {
                    b.Property<int>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CONSULTAID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsultaId"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATACONSULTA");

                    b.Property<string>("HoraConsulta")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("HORACONSULTA");

                    b.Property<string>("LocalConsulta")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("LOCALCONSULTA");

                    b.Property<int>("MedicoId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MEDICOID");

                    b.Property<string>("Mensagem")
                        .HasMaxLength(4000)
                        .HasColumnType("NCLOB")
                        .HasColumnName("MENSAGEM");

                    b.Property<int>("PacienteId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PACIENTEID");

                    b.HasKey("ConsultaId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("CONSULTA");
                });

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.MedicoModel", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MEDICOID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"));

                    b.Property<string>("Contato")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("CONTATO");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CRM");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("ESPECIALIDADE");

                    b.Property<string>("NomeMedico")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)")
                        .HasColumnName("NOMEMEDICO");

                    b.HasKey("MedicoId");

                    b.ToTable("MEDICO");
                });

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.PacienteModel", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PACIENTEID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("Contato")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("CONTATO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("EMAILPACIENTE");

                    b.Property<string>("Endereco")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("GENERO");

                    b.Property<string>("NomePaciente")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)")
                        .HasColumnName("NOMEPACIENTE");

                    b.HasKey("PacienteId");

                    b.ToTable("PACIENTE");
                });

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.ProntuarioModel", b =>
                {
                    b.Property<int>("ProntuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PRONTUARIOID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProntuarioId"));

                    b.Property<DateTime>("DataProntuario")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATAPRONTUARIO");

                    b.Property<string>("Exames")
                        .HasMaxLength(4000)
                        .HasColumnType("NCLOB")
                        .HasColumnName("EXAMES");

                    b.Property<string>("HistFamiliar")
                        .HasMaxLength(2000)
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("HISTORICOFAMILIAR");

                    b.Property<string>("HistPaciente")
                        .HasMaxLength(4000)
                        .HasColumnType("NCLOB")
                        .HasColumnName("HISTORICOPACIENTE");

                    b.Property<string>("Medicamento")
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR2(1000)")
                        .HasColumnName("MEDICAMENTO");

                    b.Property<int>("MedicoId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MEDICOID");

                    b.Property<int>("PacienteId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PACIENTEID");

                    b.Property<string>("Triagem")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR2(1000)")
                        .HasColumnName("TRIAGEM");

                    b.HasKey("ProntuarioId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PRONTUARIO");
                });

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("USUARIOID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("EMAILUSUARIO");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("NOMEUSUARIO");

                    b.Property<string>("SenhaUsuario")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR2(128)")
                        .HasColumnName("SENHAUSUARIO");

                    b.HasKey("UsuarioId");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.ConsultaModel", b =>
                {
                    b.HasOne("Fiap.Web.MVPSaude.Models.MedicoModel", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Web.MVPSaude.Models.PacienteModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Fiap.Web.MVPSaude.Models.ProntuarioModel", b =>
                {
                    b.HasOne("Fiap.Web.MVPSaude.Models.MedicoModel", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Web.MVPSaude.Models.PacienteModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}