using Microsoft.EntityFrameworkCore.Migrations;

namespace PesonalShopSolution.Migrations
{
    public partial class UpdateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Specification",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_id_specifications",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "id_brand",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "id_specifications",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "id_product",
                table: "Specification",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecificationIdSpecifications",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specification_id_product",
                table: "Specification",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SpecificationIdSpecifications",
                table: "Product",
                column: "SpecificationIdSpecifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Specification_SpecificationIdSpecifications",
                table: "Product",
                column: "SpecificationIdSpecifications",
                principalTable: "Specification",
                principalColumn: "id_specifications",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Product",
                table: "Specification",
                column: "id_product",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Specification_SpecificationIdSpecifications",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Product",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Specification_id_product",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Product_SpecificationIdSpecifications",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "id_product",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "SpecificationIdSpecifications",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "id_brand",
                table: "Specification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_specifications",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_id_specifications",
                table: "Product",
                column: "id_specifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Specification",
                table: "Product",
                column: "id_specifications",
                principalTable: "Specification",
                principalColumn: "id_specifications",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
