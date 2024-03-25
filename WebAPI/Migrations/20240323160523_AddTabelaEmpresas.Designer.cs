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
    [Migration("20240323160523_AddTabelaEmpresas")]
    partial class AddTabelaEmpresas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Motorista");
                });

            modelBuilder.Entity("WebAPI.Models.Onibus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Capacidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("EmpresaOnibusId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TemArCondicionado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

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

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("ViagemCaronaOfertaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdInstituicaoId");

                    b.HasIndex("TransportePrivadosId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("ViagemCaronaOfertaId");

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

                    b.Property<Guid>("DonoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DonoId");

                    b.ToTable("TransportesPrivados");
                });

            modelBuilder.Entity("WebAPI.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

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

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HoraSaida")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("MotoristaId")
                        .HasColumnType("char(36)");

                    b.Property<int>("NumeroVagas")
                        .HasColumnType("int");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rota")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

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

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HoraSaida")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("MotoristaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rota")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

                    b.ToTable("ViagensOnibus");
                });

            modelBuilder.Entity("WebAPI.Models.Onibus", b =>
                {
                    b.HasOne("WebAPI.Models.EmpresaOnibus", "EmpresaOnibus")
                        .WithMany("Onibus")
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

                    b.HasOne("WebAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.ViagemCaronaOferta", null)
                        .WithMany("Passageiros")
                        .HasForeignKey("ViagemCaronaOfertaId");

                    b.Navigation("IdInstituicao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPI.Models.TransportePrivados", b =>
                {
                    b.HasOne("WebAPI.Models.Usuario", "Dono")
                        .WithMany()
                        .HasForeignKey("DonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemCaronaOferta", b =>
                {
                    b.HasOne("WebAPI.Models.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("WebAPI.Models.ViagemOnibus", b =>
                {
                    b.HasOne("WebAPI.Models.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("WebAPI.Models.EmpresaOnibus", b =>
                {
                    b.Navigation("Onibus");
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
