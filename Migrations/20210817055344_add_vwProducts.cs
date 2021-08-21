using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class add_vwProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE VIEW [dbo].[vwProducts]
AS
SELECT dbo.Products.Id, dbo.Products.ProductCategoryId, dbo.ProductCategories.Name AS CategoryName, dbo.Products.Title, dbo.Products.Description, dbo.Products.Tags, dbo.Products.UserId, dbo.AspNetUsers.UserName, 
                  dbo.Products.AdminId, dbo.Products.IsConfirmed, dbo.Products.ConfirmDate, dbo.Products.CreationDate, dbo.Products.EditionDate, dbo.Products.ProductType, dbo.People.FirstName + N' ' + dbo.People.LastName AS FullName
FROM     dbo.Products INNER JOIN
                  dbo.AspNetUsers ON dbo.Products.AdminId = dbo.AspNetUsers.Id AND dbo.Products.UserId = dbo.AspNetUsers.Id INNER JOIN
                  dbo.ProductCategories ON dbo.Products.ProductCategoryId = dbo.ProductCategories.Id AND dbo.AspNetUsers.Id = dbo.ProductCategories.AdminId LEFT OUTER JOIN
                  dbo.People ON dbo.AspNetUsers.Id = dbo.People.UserId";

            migrationBuilder.Sql(sql);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP VIEW [dbo].[vwProducts]";

            migrationBuilder.Sql(sql);


            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Comments",
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
                values: new object[] { "0ce960b4-bcff-44c6-9ae1-cf3bfa9d9d96", "AQAAAAEAACcQAAAAEEP+WkgB0EdNntH8Df+Icdla2D5AVm3g1HCMWTaXhljs4WL5uAo4OnmgDgXGzUZztQ==", "1fd06555-c22e-4fee-90b1-dbcf84fe420c" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 14, 53, 49, 30, DateTimeKind.Local).AddTicks(48));
        }
    }
}
