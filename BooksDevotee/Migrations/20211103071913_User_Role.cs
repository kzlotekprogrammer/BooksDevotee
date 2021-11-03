using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksDevotee.Migrations
{
    public partial class User_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "AF67BA7A-070D-4382-A2F5-B70A628FD338", "1", "Admin", "ADMIN" },
                    { "50A16996-FE65-4508-BE89-5C1C332FB914", "2", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Business", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "StreetAndNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { "E4F51172-01BD-4181-8619-920C75A1AC06", 0, null, "Warszawa", "8e2524b4-8363-4674-a0d4-9d5a3d4f03a8", "Polska", "Admin@BooksDevotee.com", false, "Admin", "Admin", false, null, "ADMIN@BOOKSDEVOTEE.COM", "ADMIN@BOOKSDEVOTEE.COM", "AQAAAAEAACcQAAAAEISBjDypS2XUB2qWhtKShNSFYEGVK55PAi/5gLjN2Eyv4ay1H6RWvE9l65+lgM/ucw==", "123456789", false, "11-111", "cfa17484-bd23-4599-af45-da7bb785bfb0", "BooksDevotee 1", false, "Admin@BooksDevotee.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "AF67BA7A-070D-4382-A2F5-B70A628FD338", "E4F51172-01BD-4181-8619-920C75A1AC06" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50A16996-FE65-4508-BE89-5C1C332FB914");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "AF67BA7A-070D-4382-A2F5-B70A628FD338", "E4F51172-01BD-4181-8619-920C75A1AC06" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AF67BA7A-070D-4382-A2F5-B70A628FD338");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E4F51172-01BD-4181-8619-920C75A1AC06");
        }
    }
}
