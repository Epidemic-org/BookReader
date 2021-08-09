using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class testmigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ce960b4-bcff-44c6-9ae1-cf3bfa9d9d96", "AQAAAAEAACcQAAAAEEP+WkgB0EdNntH8Df+Icdla2D5AVm3g1HCMWTaXhljs4WL5uAo4OnmgDgXGzUZztQ==", "1fd06555-c22e-4fee-90b1-dbcf84fe420c" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 14, 53, 49, 30, DateTimeKind.Local).AddTicks(48));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0396e11d-6d67-44eb-8da5-e67c95bda1ee", "AQAAAAEAACcQAAAAEKW/ILNEdMLuQYmbNOfgvvhJBPlzvFvpBmhF6G7dpB5mJ/x+h4rnVQYPmpZViXvS1A==", "cfc8f9aa-5513-479d-bdbd-95519b35a783" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 28, 19, 35, 46, 475, DateTimeKind.Local).AddTicks(2228));
        }
    }
}
