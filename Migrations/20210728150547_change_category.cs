using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class change_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ProductCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9beee876-b0cd-4e0c-9822-1d818e34e377", "AQAAAAEAACcQAAAAEMz4CK0pv30dyAFJ3Hrx/Zk14fwd+Q3TTXETjEBqxAgYi3ZOKWMtJ6AlpqcsP8We/Q==", "c5c36f6c-8fc3-4c76-b78e-6fecd2d684b2" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 28, 19, 24, 10, 567, DateTimeKind.Local).AddTicks(2563));
        }
    }
}
