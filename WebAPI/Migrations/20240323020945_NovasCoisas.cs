using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NovasCoisas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_ViagensCaronaOferta_ViagemCaronaOfertaId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ViagemCaronaOfertaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ViagemCaronaOfertaId",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaId",
                table: "ViagensCaronaOferta",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Usuarios",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CNH = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransportesPrivados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportesPrivados", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ViagensOnibus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Origem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destino = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rota = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraSaida = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotoristaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViagensOnibus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViagensOnibus_Motorista_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motorista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ComprovanteInstituicao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdInstituicaoId = table.Column<int>(type: "int", nullable: false),
                    TransportePrivadosId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ViagemCaronaOfertaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passageiros_Instituicoes_IdInstituicaoId",
                        column: x => x.IdInstituicaoId,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passageiros_TransportesPrivados_TransportePrivadosId",
                        column: x => x.TransportePrivadosId,
                        principalTable: "TransportesPrivados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Passageiros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passageiros_ViagensCaronaOferta_ViagemCaronaOfertaId",
                        column: x => x.ViagemCaronaOfertaId,
                        principalTable: "ViagensCaronaOferta",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensCaronaOferta_MotoristaId",
                table: "ViagensCaronaOferta",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_IdInstituicaoId",
                table: "Passageiros",
                column: "IdInstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_TransportePrivadosId",
                table: "Passageiros",
                column: "TransportePrivadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_UsuarioId",
                table: "Passageiros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_ViagemCaronaOfertaId",
                table: "Passageiros",
                column: "ViagemCaronaOfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensOnibus_MotoristaId",
                table: "ViagensOnibus",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ViagensCaronaOferta_Motorista_MotoristaId",
                table: "ViagensCaronaOferta",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViagensCaronaOferta_Motorista_MotoristaId",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "ViagensOnibus");

            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "TransportesPrivados");

            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropIndex(
                name: "IX_ViagensCaronaOferta_MotoristaId",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Usuario",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "ViagemCaronaOfertaId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ViagemCaronaOfertaId",
                table: "Usuario",
                column: "ViagemCaronaOfertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_ViagensCaronaOferta_ViagemCaronaOfertaId",
                table: "Usuario",
                column: "ViagemCaronaOfertaId",
                principalTable: "ViagensCaronaOferta",
                principalColumn: "Id");
        }
    }
}
