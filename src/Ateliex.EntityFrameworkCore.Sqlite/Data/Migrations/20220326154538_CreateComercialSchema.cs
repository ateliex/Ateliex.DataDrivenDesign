using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ateliex.Data.Migrations
{
    public partial class CreateComercialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "comercial");

            migrationBuilder.CreateTable(
                name: "PlanoComercial",
                schema: "comercial",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RendaBrutaMensal = table.Column<decimal>(type: "TEXT", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoComercial", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "PlanoComercialCusto",
                schema: "comercial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanoComercialCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Percentual = table.Column<decimal>(type: "TEXT", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoComercialCusto", x => new { x.PlanoComercialCodigo, x.Id });
                    table.ForeignKey(
                        name: "FK_PlanoComercialCusto_PlanoComercial_PlanoComercialCodigo",
                        column: x => x.PlanoComercialCodigo,
                        principalSchema: "comercial",
                        principalTable: "PlanoComercial",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoComercialItem",
                schema: "comercial",
                columns: table => new
                {
                    PlanoComercialCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    ModeloCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    Margem = table.Column<decimal>(type: "TEXT", nullable: false),
                    MargemPercentual = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxaDeMarcacaoSugerida = table.Column<decimal>(type: "TEXT", nullable: true),
                    PrecoDeVendaDesejado = table.Column<decimal>(type: "TEXT", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoComercialItem", x => new { x.PlanoComercialCodigo, x.ModeloCodigo });
                    table.ForeignKey(
                        name: "FK_PlanoComercialItem_Modelo_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalSchema: "cadastro",
                        principalTable: "Modelo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoComercialItem_PlanoComercial_PlanoComercialCodigo",
                        column: x => x.PlanoComercialCodigo,
                        principalSchema: "comercial",
                        principalTable: "PlanoComercial",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercial",
                columns: new[] { "Codigo", "Data", "Nome", "RendaBrutaMensal" },
                values: new object[] { "PC01.A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Normal", 6000m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercial",
                columns: new[] { "Codigo", "Data", "Nome", "RendaBrutaMensal" },
                values: new object[] { "PC01.B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderado", 0m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercial",
                columns: new[] { "Codigo", "Data", "Nome", "RendaBrutaMensal" },
                values: new object[] { "PC01.C", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ousado", 0m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialCusto",
                columns: new[] { "Id", "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { 1, "PC01.A", "Prolabore", 0m, 0, 1000m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialCusto",
                columns: new[] { "Id", "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { 2, "PC01.A", "Aluguel", 0m, 0, 900m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialCusto",
                columns: new[] { "Id", "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { 3, "PC01.A", "Cartão", 10m, 1, 0m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialCusto",
                columns: new[] { "Id", "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { 4, "PC01.A", "Comissão", 10m, 1, 0m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialCusto",
                columns: new[] { "Id", "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { 5, "PC01.A", "Perda", 2m, 1, 0m });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM01", "PC01.A", 0m, 1.93m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM02", "PC01.A", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM03", "PC01.A", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM10", "PC01.A", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM01", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM02", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM03", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM04", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM05", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM06", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM07", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM08", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM09", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM10", "PC01.B", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM05", "PC01.C", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM06", "PC01.C", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM07", "PC01.C", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM08", "PC01.C", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM09", "PC01.C", 0m, 0m, null, null });

            migrationBuilder.InsertData(
                schema: "comercial",
                table: "PlanoComercialItem",
                columns: new[] { "ModeloCodigo", "PlanoComercialCodigo", "Margem", "MargemPercentual", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "TM10", "PC01.C", 0m, 0m, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoComercialItem_ModeloCodigo",
                schema: "comercial",
                table: "PlanoComercialItem",
                column: "ModeloCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoComercialCusto",
                schema: "comercial");

            migrationBuilder.DropTable(
                name: "PlanoComercialItem",
                schema: "comercial");

            migrationBuilder.DropTable(
                name: "PlanoComercial",
                schema: "comercial");
        }
    }
}
