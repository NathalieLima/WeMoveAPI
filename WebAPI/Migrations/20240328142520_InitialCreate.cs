using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpresasOnibus",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasOnibus", x => x.CNPJ);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.CNPJ);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apelido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => new { x.Id, x.Email });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Onibus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Placa = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaOnibusCNPJ = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Linha = table.Column<int>(type: "int", nullable: false),
                    TemArCondicionado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onibus", x => new { x.Id, x.Placa });
                    table.ForeignKey(
                        name: "FK_Onibus_EmpresasOnibus_EmpresaOnibusCNPJ",
                        column: x => x.EmpresaOnibusCNPJ,
                        principalTable: "EmpresasOnibus",
                        principalColumn: "CNPJ");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    CNH = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.CNH);
                    table.ForeignKey(
                        name: "FK_Motoristas_Usuarios_UsuarioId_UsuarioEmail",
                        columns: x => new { x.UsuarioId, x.UsuarioEmail },
                        principalTable: "Usuarios",
                        principalColumns: new[] { "Id", "Email" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransportesPrivados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DonoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DonoEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Placa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportesPrivados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportesPrivados_Usuarios_DonoId_DonoEmail",
                        columns: x => new { x.DonoId, x.DonoEmail },
                        principalTable: "Usuarios",
                        principalColumns: new[] { "Id", "Email" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OnibusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OnibusPlaca = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Onibus_OnibusId_OnibusPlaca",
                        columns: x => new { x.OnibusId, x.OnibusPlaca },
                        principalTable: "Onibus",
                        principalColumns: new[] { "Id", "Placa" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ViagensCaronaOferta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroVagas = table.Column<int>(type: "int", nullable: false),
                    Origem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destino = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rota = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dia = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraSaida = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    MotoristaCNH = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViagensCaronaOferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViagensCaronaOferta_Motoristas_MotoristaCNH",
                        column: x => x.MotoristaCNH,
                        principalTable: "Motoristas",
                        principalColumn: "CNH");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ViagensOnibus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OnibusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OnibusPlaca = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Origem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destino = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rota = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dia = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraSaida = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    MotoristaCNH = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViagensOnibus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViagensOnibus_Motoristas_MotoristaCNH",
                        column: x => x.MotoristaCNH,
                        principalTable: "Motoristas",
                        principalColumn: "CNH");
                    table.ForeignKey(
                        name: "FK_ViagensOnibus_Onibus_OnibusId_OnibusPlaca",
                        columns: x => new { x.OnibusId, x.OnibusPlaca },
                        principalTable: "Onibus",
                        principalColumns: new[] { "Id", "Placa" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DadosDispositivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DispositivoId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false),
                    Velocidade = table.Column<int>(type: "int", nullable: false),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    IrregularidadeSolo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QualidadeAr = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosDispositivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosDispositivos_Dispositivos_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "Dispositivos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    ComprovanteInstituicao = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstituicaoCNPJ = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransportePrivadosId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ViagemCaronaOfertaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => new { x.ComprovanteInstituicao, x.InstituicaoCNPJ });
                    table.ForeignKey(
                        name: "FK_Passageiros_TransportesPrivados_TransportePrivadosId",
                        column: x => x.TransportePrivadosId,
                        principalTable: "TransportesPrivados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Passageiros_Usuarios_UsuarioId_UsuarioEmail",
                        columns: x => new { x.UsuarioId, x.UsuarioEmail },
                        principalTable: "Usuarios",
                        principalColumns: new[] { "Id", "Email" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passageiros_ViagensCaronaOferta_ViagemCaronaOfertaId",
                        column: x => x.ViagemCaronaOfertaId,
                        principalTable: "ViagensCaronaOferta",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DadosDispositivos_DispositivoId",
                table: "DadosDispositivos",
                column: "DispositivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_OnibusId_OnibusPlaca",
                table: "Dispositivos",
                columns: new[] { "OnibusId", "OnibusPlaca" });

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_UsuarioId_UsuarioEmail",
                table: "Motoristas",
                columns: new[] { "UsuarioId", "UsuarioEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_EmpresaOnibusCNPJ",
                table: "Onibus",
                column: "EmpresaOnibusCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_TransportePrivadosId",
                table: "Passageiros",
                column: "TransportePrivadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_UsuarioId_UsuarioEmail",
                table: "Passageiros",
                columns: new[] { "UsuarioId", "UsuarioEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_ViagemCaronaOfertaId",
                table: "Passageiros",
                column: "ViagemCaronaOfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportesPrivados_DonoId_DonoEmail",
                table: "TransportesPrivados",
                columns: new[] { "DonoId", "DonoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_ViagensCaronaOferta_MotoristaCNH",
                table: "ViagensCaronaOferta",
                column: "MotoristaCNH");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensOnibus_MotoristaCNH",
                table: "ViagensOnibus",
                column: "MotoristaCNH");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensOnibus_OnibusId_OnibusPlaca",
                table: "ViagensOnibus",
                columns: new[] { "OnibusId", "OnibusPlaca" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosDispositivos");

            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "ViagensOnibus");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "TransportesPrivados");

            migrationBuilder.DropTable(
                name: "ViagensCaronaOferta");

            migrationBuilder.DropTable(
                name: "Onibus");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "EmpresasOnibus");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
