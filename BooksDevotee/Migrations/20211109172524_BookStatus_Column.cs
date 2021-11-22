using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksDevotee.Migrations
{
    public partial class BookStatus_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45dd1c09-66ef-40fe-8c94-3a8652f4dadf", "AQAAAAEAACcQAAAAEJwK+UqtitMDtyOcGaB94PhYKU1VXzC4r1mVOs6WnF5TcIWV/Tm8kUUWkKMVeOjVxw==", "fb945ce6-6c1f-4f42-ad33-81d2cd7be651" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b0eb19-bc46-4a2f-ad5a-8ff2a592a860", "AQAAAAEAACcQAAAAED1s3BgsyzYTzXPCiSWl8tvtz1VyTkI0VOlsppH+pusVqDmfkLaf0SvOLhXXq3crwg==", "d5a606aa-0352-4a1f-bff0-450f42a0965c" });
        }
    }
}
