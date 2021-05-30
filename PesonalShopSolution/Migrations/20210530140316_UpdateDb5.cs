using Microsoft.EntityFrameworkCore.Migrations;

namespace PesonalShopSolution.Migrations
{
    public partial class UpdateDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_details",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_id_order_details",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "id_order_details",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "id_order",
                table: "Order_details",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMoney",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_id_order",
                table: "Order_details",
                column: "id_order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_details_Order",
                table: "Order_details",
                column: "id_order",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_details_Order",
                table: "Order_details");

            migrationBuilder.DropIndex(
                name: "IX_Order_details_id_order",
                table: "Order_details");

            migrationBuilder.DropColumn(
                name: "id_order",
                table: "Order_details");

            migrationBuilder.DropColumn(
                name: "TotalMoney",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "id_order_details",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_id_order_details",
                table: "Order",
                column: "id_order_details");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_details",
                table: "Order",
                column: "id_order_details",
                principalTable: "Order_details",
                principalColumn: "id_order_details",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
