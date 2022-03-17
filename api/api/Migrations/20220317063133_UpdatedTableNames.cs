using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UpdatedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Order_OrderId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_user_Username",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorite_user_Username",
                table: "UserFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavorite",
                table: "UserFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "UserFavorite",
                newName: "userFavorite");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "cart");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavorite_Username",
                table: "userFavorite",
                newName: "IX_userFavorite_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Username",
                table: "order",
                newName: "IX_order_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_OrderId",
                table: "cart",
                newName: "IX_cart_OrderId");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "product",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userFavorite",
                table: "userFavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cart",
                table: "cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_order_OrderId",
                table: "cart",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_user_Username",
                table: "order",
                column: "Username",
                principalTable: "user",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_userFavorite_user_Username",
                table: "userFavorite",
                column: "Username",
                principalTable: "user",
                principalColumn: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_order_OrderId",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_order_user_Username",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_userFavorite_user_Username",
                table: "userFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userFavorite",
                table: "userFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cart",
                table: "cart");

            migrationBuilder.RenameTable(
                name: "userFavorite",
                newName: "UserFavorite");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "cart",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_userFavorite_Username",
                table: "UserFavorite",
                newName: "IX_UserFavorite_Username");

            migrationBuilder.RenameIndex(
                name: "IX_order_Username",
                table: "Order",
                newName: "IX_Order_Username");

            migrationBuilder.RenameIndex(
                name: "IX_cart_OrderId",
                table: "Cart",
                newName: "IX_Cart_OrderId");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Product",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavorite",
                table: "UserFavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Order_OrderId",
                table: "Cart",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_user_Username",
                table: "Order",
                column: "Username",
                principalTable: "user",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorite_user_Username",
                table: "UserFavorite",
                column: "Username",
                principalTable: "user",
                principalColumn: "Username");
        }
    }
}
