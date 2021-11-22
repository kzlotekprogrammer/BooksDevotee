using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksDevotee.Migrations
{
    public partial class BasketBook_Quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Baskets",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BasketBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b0eb19-bc46-4a2f-ad5a-8ff2a592a860", "AQAAAAEAACcQAAAAED1s3BgsyzYTzXPCiSWl8tvtz1VyTkI0VOlsppH+pusVqDmfkLaf0SvOLhXXq3crwg==", "d5a606aa-0352-4a1f-bff0-450f42a0965c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BasketBooks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Baskets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e2524b4-8363-4674-a0d4-9d5a3d4f03a8", "AQAAAAEAACcQAAAAEISBjDypS2XUB2qWhtKShNSFYEGVK55PAi/5gLjN2Eyv4ay1H6RWvE9l65+lgM/ucw==", "cfa17484-bd23-4599-af45-da7bb785bfb0" });
        }
    }
}
