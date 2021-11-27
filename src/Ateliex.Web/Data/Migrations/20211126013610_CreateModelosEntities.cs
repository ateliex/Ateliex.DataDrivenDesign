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
                name: "Modelos",
                schema: "cadastro",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursos",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ModeloCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursos", x => new { x.ModeloCodigo, x.Id });
                    table.ForeignKey(
                        name: "FK_ModeloRecursos_Modelos_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalSchema: "cadastro",
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[,]
                {
                    { "TM01", "Tati Model 01" },
                    { "TM02", "Tati Model 02" },
                    { "TM03", "Tati Model 03" },
                    { "TM04", "Tati Model 04" },
                    { "TM05", "Tati Model 05" },
                    { "TM06", "Tati Model 06" },
                    { "TM07", "Tati Model 07" },
                    { "TM08", "Tati Model 08" },
                    { "TM09", "Tati Model 09" },
                    { "TM10", "Tati Model 10" }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursos",
                columns: new[] { "Id", "ModeloCodigo", "Custo", "Descricao", "Tipo", "Unidades" },
                values: new object[,]
                {
                    { 1, "TM01", 20m, "Tecido", 0, 2 },
                    { 2, "TM01", 4m, "Linha", 0, 20 },
                    { 3, "TM01", 5m, "Outros", 0, 1 },
                    { 4, "TM01", 100m, "Transporte", 1, 50 },
                    { 5, "TM01", 5m, "Costureira", 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloRecursos",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Modelos",
                schema: "cadastro");
        }
    }
}
