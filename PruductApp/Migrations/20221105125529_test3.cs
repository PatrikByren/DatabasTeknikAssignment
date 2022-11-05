using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruductApp.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerEntityId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerEntityId",
                table: "Products",
                column: "CustomerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerEntityId",
                table: "Products",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustomerEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Customers");
        }
    }
}
