using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksDevotee.Migrations
{
    public partial class Basket_Dates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelDate",
                table: "Baskets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreparedDate",
                table: "Baskets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c31c74d-fa78-4e52-ac6e-8cd8bb097d18", "AQAAAAEAACcQAAAAEFFiE6TO5E2y5HQUqNc6Zn9/y++OG4lnCiTgkM53He1402KxHnUj239t5Q775K1Qrg==", "a42c8661-37a4-487c-831d-40b607f84ebb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelDate",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "PreparedDate",
                table: "Baskets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b11b3758-618e-426f-88de-4ef38b0f82a5", "AQAAAAEAACcQAAAAENmIoea/YUF2e8ck5Gn0hmAxAPo1KJcCtFgFncLUCJLTRZwCwoRc8i73AwJlYUt/RA==", "e195b9ba-d9ce-4036-8836-6c90e5da2a8d" });
        }
    }
}
