using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repository.Migrations
{
    public partial class AlterModel_Jogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassificacaoIndicativas",
                table: "ClassificacaoIndicativas");

            migrationBuilder.RenameTable(
                name: "ClassificacaoIndicativas",
                newName: "Classificacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classificacoes",
                table: "Classificacoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_ClassificacaoId",
                table: "Jogos",
                column: "ClassificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_GeneroId",
                table: "Jogos",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Classificacoes_ClassificacaoId",
                table: "Jogos",
                column: "ClassificacaoId",
                principalTable: "Classificacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Generos_GeneroId",
                table: "Jogos",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Classificacoes_ClassificacaoId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Generos_GeneroId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_ClassificacaoId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_GeneroId",
                table: "Jogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classificacoes",
                table: "Classificacoes");

            migrationBuilder.RenameTable(
                name: "Classificacoes",
                newName: "ClassificacaoIndicativas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassificacaoIndicativas",
                table: "ClassificacaoIndicativas",
                column: "Id");
        }
    }
}
