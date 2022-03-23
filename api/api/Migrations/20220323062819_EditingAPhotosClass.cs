using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class EditingAPhotosClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photo_product_ProductId",
                table: "photo");

            migrationBuilder.DropForeignKey(
                name: "FK_photo_user_Username",
                table: "photo");

            migrationBuilder.DropIndex(
                name: "IX_photo_Username",
                table: "photo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "photo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "photo");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "photo");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "photo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_photo_product_ProductId",
                table: "photo",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photo_product_ProductId",
                table: "photo");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "photo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "photo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "photo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "photo",
                type: "varchar(95)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_photo_Username",
                table: "photo",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_photo_product_ProductId",
                table: "photo",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_photo_user_Username",
                table: "photo",
                column: "Username",
                principalTable: "user",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
