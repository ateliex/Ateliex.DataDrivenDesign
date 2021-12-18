using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ateliex.Data.Migrations
{
    public partial class CreateCadastroSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cadastro");

            migrationBuilder.CreateTable(
                name: "Modelo",
                schema: "cadastro",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoTipo",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecurso",
                schema: "cadastro",
                columns: table => new
                {
                    ModeloCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", precision: 14, scale: 2, nullable: false),
                    Unidades = table.Column<int>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecurso", x => new { x.ModeloCodigo, x.Id });
                    table.ForeignKey(
                        name: "FK_ModeloRecurso_Modelo_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalSchema: "cadastro",
                        principalTable: "Modelo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeloRecurso_ModeloRecursoTipo_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM01", "Tati Model 01" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM02", "Tati Model 02" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM03", "Tati Model 03" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM04", "Tati Model 04" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM05", "Tati Model 05" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM06", "Tati Model 06" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM07", "Tati Model 07" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM08", "Tati Model 08" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM09", "Tati Model 09" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM10", "Tati Model 10" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Material" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Transporte" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Humano" });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecurso",
                columns: new[] { "Id", "ModeloCodigo", "Custo", "Descricao", "TipoId", "Unidades" },
                values: new object[] { 1, "TM01", 20m, "Tecido", 1, 2 });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecurso",
                columns: new[] { "Id", "ModeloCodigo", "Custo", "Descricao", "TipoId", "Unidades" },
                values: new object[] { 2, "TM01", 4m, "Linha", 1, 20 });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecurso",
                columns: new[] { "Id", "ModeloCodigo", "Custo", "Descricao", "TipoId", "Unidades" },
                values: new object[] { 3, "TM01", 5m, "Outros", 1, 1 });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecurso",
                columns: new[] { "Id", "ModeloCodigo", "Custo", "Descricao", "TipoId", "Unidades" },
                values: new object[] { 4, "TM01", 100m, "Transporte", 2, 50 });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecurso",
                columns: new[] { "Id", "ModeloCodigo", "Custo", "Descricao", "TipoId", "Unidades" },
                values: new object[] { 5, "TM01", 5m, "Costureira", 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecurso_TipoId",
                schema: "cadastro",
                table: "ModeloRecurso",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloRecurso",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Modelo",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoTipo",
                schema: "cadastro");
        }
    }
}
