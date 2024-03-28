﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonsApi.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240326021025_MaisAtt")]
    partial class MaisAtt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAPI.Models.Dispositivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("NomeFornecedora")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("OnibusId")
                        .HasColumnType("char(36)");

                    b.Property<string>("OnibusPlaca")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("OnibusId", "OnibusPlaca");

                    b.ToTable("Dispositivos");
                });

            modelBuilder.Entity("WebAPI.Models.EmpresaOnibus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EmpresasOnibus");
                });

            modelBuilder.Entity("WebAPI.Models.Instituicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("WebAPI.Models.Motorista", b =>
                {
                    b.Property<string>("CNH")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("CNH");

                    b.HasIndex("UsuarioId", "UsuarioEmail");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("WebAPI.Models.Onibus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Placa")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Capacidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("EmpresaOnibusId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Linha")
                        .HasColumnType("int");

                    b.Property<bool>("TemArCondicionado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id", "Placa");

                    b.HasIndex("EmpresaOnibusId");

                    b.ToTable("Onibus");
                });

            modelBuilder.Entity("WebAPI.Models.Passageiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ComprovanteInstituicao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdInstituicaoId")
                        .HasColumnType("int");

                    b.Property<Guid?>("TransportePrivadosId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("ViagemCaronaOfertaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdInstituicaoId");

                    b.HasIndex("TransportePrivadosId");

                    b.HasIndex("ViagemCaronaOfertaId");

                    b.HasIndex("UsuarioId", "UsuarioEmail");

                    b.ToTable("Passageiros");
                });

            modelBuilder.Entity("WebAPI.Models.TransportePrivados", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Capacidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DonoEmail")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("DonoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DonoId", "DonoEmail");

                    b.ToTable("TransportesPrivados");
                });

            modelBuilder.Entity("WebAPI.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id", "Email");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemCaronaOferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("Dia")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("HoraSaida")
                        .HasColumnType("time(6)");

                    b.Property<string>("MotoristaCNH")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NumeroVagas")
                        .HasColumnType("int");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rota")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaCNH");

                    b.ToTable("ViagensCaronaOferta");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemOnibus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("Dia")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("HoraSaida")
                        .HasColumnType("time(6)");

                    b.Property<string>("MotoristaCNH")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rota")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaCNH");

                    b.ToTable("ViagensOnibus");
                });

            modelBuilder.Entity("WebAPI.Models.Dispositivo", b =>
                {
                    b.HasOne("WebAPI.Models.Onibus", "Onibus")
                        .WithMany()
                        .HasForeignKey("OnibusId", "OnibusPlaca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Onibus");
                });

            modelBuilder.Entity("WebAPI.Models.Motorista", b =>
                {
                    b.HasOne("WebAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId", "UsuarioEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPI.Models.Onibus", b =>
                {
                    b.HasOne("WebAPI.Models.EmpresaOnibus", "EmpresaOnibus")
                        .WithMany()
                        .HasForeignKey("EmpresaOnibusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmpresaOnibus");
                });

            modelBuilder.Entity("WebAPI.Models.Passageiro", b =>
                {
                    b.HasOne("WebAPI.Models.Instituicao", "IdInstituicao")
                        .WithMany()
                        .HasForeignKey("IdInstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.TransportePrivados", null)
                        .WithMany("Passageiros")
                        .HasForeignKey("TransportePrivadosId");

                    b.HasOne("WebAPI.Models.ViagemCaronaOferta", null)
                        .WithMany("Passageiros")
                        .HasForeignKey("ViagemCaronaOfertaId");

                    b.HasOne("WebAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId", "UsuarioEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdInstituicao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPI.Models.TransportePrivados", b =>
                {
                    b.HasOne("WebAPI.Models.Usuario", "Dono")
                        .WithMany()
                        .HasForeignKey("DonoId", "DonoEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemCaronaOferta", b =>
                {
                    b.HasOne("WebAPI.Models.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaCNH");

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemOnibus", b =>
                {
                    b.HasOne("WebAPI.Models.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaCNH");

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("WebAPI.Models.TransportePrivados", b =>
                {
                    b.Navigation("Passageiros");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemCaronaOferta", b =>
                {
                    b.Navigation("Passageiros");
                });
#pragma warning restore 612, 618
        }
    }
}