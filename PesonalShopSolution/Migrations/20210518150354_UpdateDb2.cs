using Microsoft.EntityFrameworkCore.Migrations;

namespace PesonalShopSolution.Migrations
{
    public partial class UpdateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Cart_details",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Trademark",
                table: "Specification");

            migrationBuilder.DropTable(
                name: "Cart_details");

            migrationBuilder.DropIndex(
                name: "IX_Specification_id_brand",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Cart_id_cart_details",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Specification");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Specification",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Cart",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalMoney",
                table: "Cart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "TotalMoney",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Specification",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    id_product = table.Column<int>(type: "int", nullable: true),
                    Total_money = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cart_details_Product",
                        column: x => x.id_product,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specification_id_brand",
                table: "Specification",
                column: "id_brand");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_id_cart_details",
                table: "Cart",
                column: "id_cart_details");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_details_id_product",
                table: "Cart_details",
                column: "id_product");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Cart_details",
                table: "Cart",
                column: "id_cart_details",
                principalTable: "Cart_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Trademark",
                table: "Specification",
                column: "id_brand",
                principalTable: "Brand",
                principalColumn: "id_brand",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
