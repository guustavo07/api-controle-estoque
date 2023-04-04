using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIChurrascaria.Migrations
{
    public partial class AddUpdateMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId1",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_ProdutoId1",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "Estoques");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos",
                column: "EstoqueId",
                principalTable: "Estoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "Estoques",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoId1",
                table: "Estoques",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId1",
                table: "Estoques",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
