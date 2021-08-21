using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class editvwproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9deff32d-b27f-4df9-b01c-79b48ab716c6", "AQAAAAEAACcQAAAAEEfBCri5Xmfe+QtCG71Yrg2T6KxbqdD/DT6NvU2626aMD/QHIo7pMsGmopJhrpyeuw==", "0ead66ba-3170-49ef-afad-c630bf866754" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 17, 10, 23, 43, 299, DateTimeKind.Local).AddTicks(7772));
        }
    }
}
