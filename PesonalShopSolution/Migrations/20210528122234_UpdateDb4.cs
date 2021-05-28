using Microsoft.EntityFrameworkCore.Migrations;

namespace PesonalShopSolution.Migrations
{
    public partial class UpdateDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_IdUser",
                table: "Cart",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers",
                table: "Cart",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_IdUser",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Cart");
        }
    }
}
