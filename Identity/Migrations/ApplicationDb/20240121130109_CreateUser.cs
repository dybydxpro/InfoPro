using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class CreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AdminIdentifire", "City", "CompanyContact", "CompanyEmail", "CompanyName", "CreatedOn", "IsDeleted", "PostalCode", "UpdatedOn", "Website" },
                values: new object[] { 1, "No 271", "Main Street", "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846", "Matara", "0779200039", "tharindutd1998@gmail.com", "InfoPro", new DateTime(2024, 1, 21, 18, 31, 8, 822, DateTimeKind.Local).AddTicks(9006), false, "81000", new DateTime(2024, 1, 21, 18, 31, 8, 822, DateTimeKind.Local).AddTicks(9006), "infopro.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "CompanyId", "CreatedOn", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "UpdatedOn", "UserIdentifier" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 1, 21, 18, 31, 8, 822, DateTimeKind.Local).AddTicks(9006), "tharindutd1998@gmail.com", "InfoPro", false, "Admin", "0779200039", new DateTime(2024, 1, 21, 18, 31, 8, 822, DateTimeKind.Local).AddTicks(9006), "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
