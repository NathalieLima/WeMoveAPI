using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaEmpresas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Capacidade",
                table: "TransportesPrivados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "DonoId",
                table: "TransportesPrivados",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "TransportesPrivados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "TransportesPrivados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpresasOnibus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasOnibus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Onibus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmpresaOnibusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TemArCondicionado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Placa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onibus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onibus_EmpresasOnibus_EmpresaOnibusId",
                        column: x => x.EmpresaOnibusId,
                        principalTable: "EmpresasOnibus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransportesPrivados_DonoId",
                table: "TransportesPrivados",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_EmpresaOnibusId",
                table: "Onibus",
                column: "EmpresaOnibusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportesPrivados_Usuarios_DonoId",
                table: "TransportesPrivados",
                column: "DonoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportesPrivados_Usuarios_DonoId",
                table: "TransportesPrivados");

            migrationBuilder.DropTable(
                name: "Onibus");

            migrationBuilder.DropTable(
                name: "EmpresasOnibus");

            migrationBuilder.DropIndex(
                name: "IX_TransportesPrivados_DonoId",
                table: "TransportesPrivados");

            migrationBuilder.DropColumn(
                name: "Capacidade",
                table: "TransportesPrivados");

            migrationBuilder.DropColumn(
                name: "DonoId",
                table: "TransportesPrivados");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "TransportesPrivados");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "TransportesPrivados");
        }
    }
}
