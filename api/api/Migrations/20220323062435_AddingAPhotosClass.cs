using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AddingAPhotosClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "cart",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "cart",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "cart",
                newName: "Price");

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    Username = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photo_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_photo_user_Username",
                        column: x => x.Username,
                        principalTable: "user",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_photo_ProductId",
                table: "photo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_photo_Username",
                table: "photo",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "cart",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "cart",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "cart",
                newName: "price");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "product",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
