using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateEmployeeToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NIC",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 23, 3, 2, 606, DateTimeKind.Local).AddTicks(4489), new DateTime(2024, 2, 24, 23, 3, 2, 606, DateTimeKind.Local).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 23, 3, 2, 606, DateTimeKind.Local).AddTicks(4489), new DateTime(2024, 2, 24, 23, 3, 2, 606, DateTimeKind.Local).AddTicks(4489) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NIC",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 22, 33, 57, 131, DateTimeKind.Local).AddTicks(7411), new DateTime(2024, 2, 24, 22, 33, 57, 131, DateTimeKind.Local).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 22, 33, 57, 131, DateTimeKind.Local).AddTicks(7411), new DateTime(2024, 2, 24, 22, 33, 57, 131, DateTimeKind.Local).AddTicks(7411) });
        }
    }
}
