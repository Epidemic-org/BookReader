using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class editproductVw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b56634-4c6a-436a-a57d-e11f0ee94e7c", "AQAAAAEAACcQAAAAENT610FqsZGXXPLjjvVEVjCWPRQmTibSIZYtSt2hzUwytf/MUzfoUReoExIHo8J+Dw==", "5119ade5-a8a9-49cb-81d9-9dd5f5b91836" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 19, 58, 57, 827, DateTimeKind.Local).AddTicks(5703));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e70bfe-3a21-4ab2-b6f1-64540db57ef2", "AQAAAAEAACcQAAAAEHOQonuN5veTOKyuNtw3DwD7sg7NAuOMNSlIQqg0BcyY0wP0i7zbwsAQqoBOqYNuIw==", "b86304a9-0ab7-4fac-a3e4-cc657352a24c" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 19, 19, 56, 20, 572, DateTimeKind.Local).AddTicks(1781));
        }
    }
}
