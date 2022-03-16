using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class CateringForLinuxCaseSensitivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_Username",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorite_User_Username",
                table: "UserFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Username");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_user_Username",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorite_user_Username",
                table: "UserFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_Username",
                table: "Order",
                column: "Username",
                principalTable: "User",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorite_User_Username",
                table: "UserFavorite",
                column: "Username",
                principalTable: "User",
                principalColumn: "Username");
        }
    }
}
