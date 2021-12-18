using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ateliex.Data.Migrations
{
    public partial class UpgradeModeloEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursoAnexos_ModeloRecursos_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursoObservacoes_ModeloRecursos_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursos_ModeloRecursoTipos_TipoId",
                schema: "cadastro",
                table: "ModeloRecursos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursos_Modelos_ModeloId",
                schema: "cadastro",
                table: "ModeloRecursos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursoTipoDescricoes_ModeloRecursoTipos_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelos",
                schema: "cadastro",
                table: "Modelos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoTipos",
                schema: "cadastro",
                table: "ModeloRecursoTipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoTipoDescricoes",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursos",
                schema: "cadastro",
                table: "ModeloRecursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoObservacoes",
                schema: "cadastro",
                table: "ModeloRecursoObservacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoAnexos",
                schema: "cadastro",
                table: "ModeloRecursoAnexos");

            migrationBuilder.RenameTable(
                name: "Modelos",
                schema: "cadastro",
                newName: "Modelo",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoTipos",
                schema: "cadastro",
                newName: "ModeloRecursoTipo",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoTipoDescricoes",
                schema: "cadastro",
                newName: "ModeloRecursoTipoDescricao",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursos",
                schema: "cadastro",
                newName: "ModeloRecurso",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoObservacoes",
                schema: "cadastro",
                newName: "ModeloRecursoObservacao",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoAnexos",
                schema: "cadastro",
                newName: "ModeloRecursoAnexo",
                newSchema: "cadastro");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursoTipoDescricoes_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao",
                newName: "IX_ModeloRecursoTipoDescricao_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursos_TipoId",
                schema: "cadastro",
                table: "ModeloRecurso",
                newName: "IX_ModeloRecurso_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursos_ModeloId",
                schema: "cadastro",
                table: "ModeloRecurso",
                newName: "IX_ModeloRecurso_ModeloId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursoObservacoes_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacao",
                newName: "IX_ModeloRecursoObservacao_RecursoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursoAnexos_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexo",
                newName: "IX_ModeloRecursoAnexo_RecursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelo",
                schema: "cadastro",
                table: "Modelo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoTipo",
                schema: "cadastro",
                table: "ModeloRecursoTipo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoTipoDescricao",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecurso",
                schema: "cadastro",
                table: "ModeloRecurso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoObservacao",
                schema: "cadastro",
                table: "ModeloRecursoObservacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoAnexo",
                schema: "cadastro",
                table: "ModeloRecursoAnexo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecurso_Modelo_ModeloId",
                schema: "cadastro",
                table: "ModeloRecurso",
                column: "ModeloId",
                principalSchema: "cadastro",
                principalTable: "Modelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecurso_ModeloRecursoTipo_TipoId",
                schema: "cadastro",
                table: "ModeloRecurso",
                column: "TipoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecursoTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursoAnexo_ModeloRecurso_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexo",
                column: "RecursoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursoObservacao_ModeloRecurso_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacao",
                column: "RecursoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursoTipoDescricao_ModeloRecursoTipo_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao",
                column: "TipoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecursoTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecurso_Modelo_ModeloId",
                schema: "cadastro",
                table: "ModeloRecurso");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecurso_ModeloRecursoTipo_TipoId",
                schema: "cadastro",
                table: "ModeloRecurso");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursoAnexo_ModeloRecurso_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexo");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursoObservacao_ModeloRecurso_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacao");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeloRecursoTipoDescricao_ModeloRecursoTipo_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoTipoDescricao",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoTipo",
                schema: "cadastro",
                table: "ModeloRecursoTipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoObservacao",
                schema: "cadastro",
                table: "ModeloRecursoObservacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecursoAnexo",
                schema: "cadastro",
                table: "ModeloRecursoAnexo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeloRecurso",
                schema: "cadastro",
                table: "ModeloRecurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelo",
                schema: "cadastro",
                table: "Modelo");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoTipoDescricao",
                schema: "cadastro",
                newName: "ModeloRecursoTipoDescricoes",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoTipo",
                schema: "cadastro",
                newName: "ModeloRecursoTipos",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoObservacao",
                schema: "cadastro",
                newName: "ModeloRecursoObservacoes",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecursoAnexo",
                schema: "cadastro",
                newName: "ModeloRecursoAnexos",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "ModeloRecurso",
                schema: "cadastro",
                newName: "ModeloRecursos",
                newSchema: "cadastro");

            migrationBuilder.RenameTable(
                name: "Modelo",
                schema: "cadastro",
                newName: "Modelos",
                newSchema: "cadastro");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursoTipoDescricao_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes",
                newName: "IX_ModeloRecursoTipoDescricoes_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursoObservacao_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacoes",
                newName: "IX_ModeloRecursoObservacoes_RecursoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecursoAnexo_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexos",
                newName: "IX_ModeloRecursoAnexos_RecursoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecurso_TipoId",
                schema: "cadastro",
                table: "ModeloRecursos",
                newName: "IX_ModeloRecursos_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeloRecurso_ModeloId",
                schema: "cadastro",
                table: "ModeloRecursos",
                newName: "IX_ModeloRecursos_ModeloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoTipoDescricoes",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoTipos",
                schema: "cadastro",
                table: "ModeloRecursoTipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoObservacoes",
                schema: "cadastro",
                table: "ModeloRecursoObservacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursoAnexos",
                schema: "cadastro",
                table: "ModeloRecursoAnexos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeloRecursos",
                schema: "cadastro",
                table: "ModeloRecursos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelos",
                schema: "cadastro",
                table: "Modelos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursoAnexos_ModeloRecursos_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexos",
                column: "RecursoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursoObservacoes_ModeloRecursos_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacoes",
                column: "RecursoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursos_ModeloRecursoTipos_TipoId",
                schema: "cadastro",
                table: "ModeloRecursos",
                column: "TipoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecursoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursos_Modelos_ModeloId",
                schema: "cadastro",
                table: "ModeloRecursos",
                column: "ModeloId",
                principalSchema: "cadastro",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloRecursoTipoDescricoes_ModeloRecursoTipos_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricoes",
                column: "TipoId",
                principalSchema: "cadastro",
                principalTable: "ModeloRecursoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
