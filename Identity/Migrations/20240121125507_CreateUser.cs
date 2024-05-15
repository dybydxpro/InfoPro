using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class CreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AuthId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846", 0, 1, "776c7622-8ad0-484c-bf59-fb390dda1389", "tharindutd1998@gmail.com", true, "InfoPro", null, "Admin", true, null, "THARINDUTD1998@GMAIL.COM", "THARINDUTD1998@GMAIL.COM", "AQAAAAIAAYagAAAAEO2NZlDTC/AeRvEjQo61i7uEks7JlX0uxUFaBUIQlLiGiSZxHu7uIW43BUEoxe1fAA==", null, false, "ENOMQ2ITQD77EWDHLT572ZGEFSI3GDOO", false, "tharindutd1998@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");
        }
    }
}
