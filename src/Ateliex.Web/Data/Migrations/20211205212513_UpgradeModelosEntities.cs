using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ateliex.Data.Migrations
{
    public partial class UpgradeModelosEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModeloRecursoAnexos",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Arquivo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursoAnexos_ModeloRecursos_RecursoId",
                        column: x => x.RecursoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoObservacoes",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoObservacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursoObservacoes_ModeloRecursos_RecursoId",
                        column: x => x.RecursoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoTipoDescricoes",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoTipoDescricoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursoTipoDescricoes_ModeloRecursoTipos_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoAnexos",
                columns: new[] { "Id", "Arquivo", "Nome", "RecursoId" },
                values: new object[,]
                {
                    { 1, new byte[0], "Arquivo 1", 2 },
                    { 2, new byte[0], "Arquivo 2", 2 },
                    { 3, new byte[0], "Arquivo 1", 3 }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoObservacoes",
                columns: new[] { "Id", "RecursoId", "Texto" },
                values: new object[] { 1, 3, "Sit lorem torquent sociosqu molestie litora mauris commodo, inceptos vel dui fames tellus pulvinar curabitur luctus, faucibus integer augue pretium neque justo. senectus elementum pulvinar justo cubilia vivamus laoreet enim per, habitant ullamcorper condimentum elementum ultrices erat pretium neque ornare, proin quisque ultricies libero vulputate aliquet sollicitudin. accumsan porttitor aliquam conubia nec netus sapien euismod nam laoreet sociosqu, quisque semper nullam nostra euismod odio amet accumsan pellentesque, aenean elit convallis sodales elementum tristique dictumst vulputate mi. torquent aliquam augue condimentum pulvinar fames platea suscipit donec, conubia sodales ad viverra nam euismod vivamus bibendum, fermentum at rutrum semper augue egestas tortor." });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes",
                columns: new[] { "Id", "Texto", "TipoId" },
                values: new object[] { 1, "Lorem ipsum urna elit aptent euismod vulputate tristique, etiam eget arcu class tempus eu id class, tristique senectus commodo aenean consequat velit. ornare nisi class torquent nunc elementum nostra elementum condimentum sapien convallis, orci aptent maecenas sed mauris pretium diam nulla quisque, metus sem integer ornare aliquam vitae taciti dictumst eros. enim sit curabitur eleifend etiam aenean quisque in quis interdum nulla dolor porta consequat etiam vehicula maecenas platea placerat vitae, bibendum nunc aenean tempor nulla ultrices nec sem sociosqu dictum iaculis aliquam vulputate pellentesque dapibus per elit. amet eu suspendisse condimentum a porttitor nulla quam proin, curabitur feugiat semper eros placerat iaculis proin, maecenas senectus quisque phasellus luctus convallis rutrum.", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursoAnexos_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursoObservacoes_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacoes",
                column: "RecursoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursoTipoDescricoes_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes",
                column: "TipoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloRecursoAnexos",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoObservacoes",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoTipoDescricoes",
                schema: "cadastro");
        }
    }
}
