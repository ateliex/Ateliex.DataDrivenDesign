using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ateliex.Data.Migrations
{
    public partial class CreateModelosEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cadastro");

            migrationBuilder.CreateTable(
                name: "ModeloRecursoTipos",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursos",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursos_ModeloRecursoTipos_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeloRecursos_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalSchema: "cadastro",
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Material" },
                    { 2, "Transporte" },
                    { 3, "Humano" }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tati Model 01" },
                    { 2, "Tati Model 02" },
                    { 3, "Tati Model 03" },
                    { 4, "Tati Model 04" },
                    { 5, "Tati Model 05" },
                    { 6, "Tati Model 06" },
                    { 7, "Tati Model 07" },
                    { 8, "Tati Model 08" },
                    { 9, "Tati Model 09" },
                    { 10, "Tati Model 10" }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursos",
                columns: new[] { "Id", "Custo", "Descricao", "ModeloId", "TipoId", "Unidades" },
                values: new object[,]
                {
                    { 1, 20m, "Tecido", 1, 1, 2 },
                    { 2, 4m, "Linha", 1, 1, 20 },
                    { 3, 5m, "Outros", 1, 1, 1 },
                    { 4, 100m, "Transporte", 1, 2, 50 },
                    { 5, 5m, "Costureira", 1, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursos_ModeloId",
                schema: "cadastro",
                table: "ModeloRecursos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursos_TipoId",
                schema: "cadastro",
                table: "ModeloRecursos",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloRecursos",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoTipos",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Modelos",
                schema: "cadastro");
        }
    }
}
