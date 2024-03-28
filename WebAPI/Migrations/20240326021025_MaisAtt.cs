using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class MaisAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Usuarios_UsuarioId",
                table: "Passageiros");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportesPrivados_Usuarios_DonoId",
                table: "TransportesPrivados");

            migrationBuilder.DropForeignKey(
                name: "FK_ViagensCaronaOferta_Motorista_MotoristaId",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropForeignKey(
                name: "FK_ViagensOnibus_Motorista_MotoristaId",
                table: "ViagensOnibus");

            migrationBuilder.DropIndex(
                name: "IX_ViagensOnibus_MotoristaId",
                table: "ViagensOnibus");

            migrationBuilder.DropIndex(
                name: "IX_ViagensCaronaOferta_MotoristaId",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_TransportesPrivados_DonoId",
                table: "TransportesPrivados");

            migrationBuilder.DropIndex(
                name: "IX_Passageiros_UsuarioId",
                table: "Passageiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onibus",
                table: "Onibus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motorista",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "ViagensOnibus");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "TransportesPrivados");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Motorista");

            migrationBuilder.RenameTable(
                name: "Motorista",
                newName: "Motoristas");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Motoristas",
                newName: "UsuarioId");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "HoraSaida",
                table: "ViagensOnibus",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dia",
                table: "ViagensOnibus",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "MotoristaCNH",
                table: "ViagensOnibus",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "HoraSaida",
                table: "ViagensCaronaOferta",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dia",
                table: "ViagensCaronaOferta",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "MotoristaCNH",
                table: "ViagensCaronaOferta",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DonoEmail",
                table: "TransportesPrivados",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEmail",
                table: "Passageiros",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Onibus",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Linha",
                table: "Onibus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CNH",
                table: "Motoristas",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEmail",
                table: "Motoristas",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                columns: new[] { "Id", "Email" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onibus",
                table: "Onibus",
                columns: new[] { "Id", "Placa" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motoristas",
                table: "Motoristas",
                column: "CNH");

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeFornecedora = table.Column<string>(type: "longtext", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ViagensOnibus_MotoristaCNH",
                table: "ViagensOnibus",
                column: "MotoristaCNH");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensCaronaOferta_MotoristaCNH",
                table: "ViagensCaronaOferta",
                column: "MotoristaCNH");

            migrationBuilder.CreateIndex(
                name: "IX_TransportesPrivados_DonoId_DonoEmail",
                table: "TransportesPrivados",
                columns: new[] { "DonoId", "DonoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_UsuarioId_UsuarioEmail",
                table: "Passageiros",
                columns: new[] { "UsuarioId", "UsuarioEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_UsuarioId_UsuarioEmail",
                table: "Motoristas",
                columns: new[] { "UsuarioId", "UsuarioEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_OnibusId_OnibusPlaca",
                table: "Dispositivos",
                columns: new[] { "OnibusId", "OnibusPlaca" });

            migrationBuilder.AddForeignKey(
                name: "FK_Motoristas_Usuarios_UsuarioId_UsuarioEmail",
                table: "Motoristas",
                columns: new[] { "UsuarioId", "UsuarioEmail" },
                principalTable: "Usuarios",
                principalColumns: new[] { "Id", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Usuarios_UsuarioId_UsuarioEmail",
                table: "Passageiros",
                columns: new[] { "UsuarioId", "UsuarioEmail" },
                principalTable: "Usuarios",
                principalColumns: new[] { "Id", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportesPrivados_Usuarios_DonoId_DonoEmail",
                table: "TransportesPrivados",
                columns: new[] { "DonoId", "DonoEmail" },
                principalTable: "Usuarios",
                principalColumns: new[] { "Id", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViagensCaronaOferta_Motoristas_MotoristaCNH",
                table: "ViagensCaronaOferta",
                column: "MotoristaCNH",
                principalTable: "Motoristas",
                principalColumn: "CNH");

            migrationBuilder.AddForeignKey(
                name: "FK_ViagensOnibus_Motoristas_MotoristaCNH",
                table: "ViagensOnibus",
                column: "MotoristaCNH",
                principalTable: "Motoristas",
                principalColumn: "CNH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Usuarios_UsuarioId_UsuarioEmail",
                table: "Motoristas");

            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Usuarios_UsuarioId_UsuarioEmail",
                table: "Passageiros");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportesPrivados_Usuarios_DonoId_DonoEmail",
                table: "TransportesPrivados");

            migrationBuilder.DropForeignKey(
                name: "FK_ViagensCaronaOferta_Motoristas_MotoristaCNH",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropForeignKey(
                name: "FK_ViagensOnibus_Motoristas_MotoristaCNH",
                table: "ViagensOnibus");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropIndex(
                name: "IX_ViagensOnibus_MotoristaCNH",
                table: "ViagensOnibus");

            migrationBuilder.DropIndex(
                name: "IX_ViagensCaronaOferta_MotoristaCNH",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_TransportesPrivados_DonoId_DonoEmail",
                table: "TransportesPrivados");

            migrationBuilder.DropIndex(
                name: "IX_Passageiros_UsuarioId_UsuarioEmail",
                table: "Passageiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onibus",
                table: "Onibus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motoristas",
                table: "Motoristas");

            migrationBuilder.DropIndex(
                name: "IX_Motoristas_UsuarioId_UsuarioEmail",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "MotoristaCNH",
                table: "ViagensOnibus");

            migrationBuilder.DropColumn(
                name: "MotoristaCNH",
                table: "ViagensCaronaOferta");

            migrationBuilder.DropColumn(
                name: "DonoEmail",
                table: "TransportesPrivados");

            migrationBuilder.DropColumn(
                name: "UsuarioEmail",
                table: "Passageiros");

            migrationBuilder.DropColumn(
                name: "Linha",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "UsuarioEmail",
                table: "Motoristas");

            migrationBuilder.RenameTable(
                name: "Motoristas",
                newName: "Motorista");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Motorista",
                newName: "IdUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "HoraSaida",
                table: "ViagensOnibus",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dia",
                table: "ViagensOnibus",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaId",
                table: "ViagensOnibus",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "HoraSaida",
                table: "ViagensCaronaOferta",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dia",
                table: "ViagensCaronaOferta",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaId",
                table: "ViagensCaronaOferta",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "TransportesPrivados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Onibus",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Onibus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CNH",
                table: "Motorista",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Motorista",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onibus",
                table: "Onibus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motorista",
                table: "Motorista",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensOnibus_MotoristaId",
                table: "ViagensOnibus",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ViagensCaronaOferta_MotoristaId",
                table: "ViagensCaronaOferta",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportesPrivados_DonoId",
                table: "TransportesPrivados",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_UsuarioId",
                table: "Passageiros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Usuarios_UsuarioId",
                table: "Passageiros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportesPrivados_Usuarios_DonoId",
                table: "TransportesPrivados",
                column: "DonoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViagensCaronaOferta_Motorista_MotoristaId",
                table: "ViagensCaronaOferta",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViagensOnibus_Motorista_MotoristaId",
                table: "ViagensOnibus",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
