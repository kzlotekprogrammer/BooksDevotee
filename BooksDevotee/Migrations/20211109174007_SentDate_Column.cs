using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksDevotee.Migrations
{
    public partial class SentDate_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Baskets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b11b3758-618e-426f-88de-4ef38b0f82a5", "AQAAAAEAACcQAAAAENmIoea/YUF2e8ck5Gn0hmAxAPo1KJcCtFgFncLUCJLTRZwCwoRc8i73AwJlYUt/RA==", "e195b9ba-d9ce-4036-8836-6c90e5da2a8d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Baskets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45dd1c09-66ef-40fe-8c94-3a8652f4dadf", "AQAAAAEAACcQAAAAEJwK+UqtitMDtyOcGaB94PhYKU1VXzC4r1mVOs6WnF5TcIWV/Tm8kUUWkKMVeOjVxw==", "fb945ce6-6c1f-4f42-ad33-81d2cd7be651" });
        }
    }
}
