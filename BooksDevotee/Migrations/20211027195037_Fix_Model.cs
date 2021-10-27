using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BooksDevotee.Migrations
{
    public partial class Fix_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketBooks",
                table: "BasketBooks");

            migrationBuilder.DropIndex(
                name: "IX_BasketBooks_BookId",
                table: "BasketBooks");

            migrationBuilder.DropColumn(
                name: "BookCategoryId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "BasketBookId",
                table: "BasketBooks");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketBooks",
                table: "BasketBooks",
                columns: new[] { "BookId", "BasketId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketBooks",
                table: "BasketBooks");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "BookCategoryId",
                table: "BookCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BasketBookId",
                table: "BasketBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                column: "BookCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketBooks",
                table: "BasketBooks",
                column: "BasketBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketBooks_BookId",
                table: "BasketBooks",
                column: "BookId");
        }
    }
}
