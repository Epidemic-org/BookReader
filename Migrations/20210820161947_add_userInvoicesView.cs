using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class add_userInvoicesView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) {

            var sql = @"CREATE VIEW [dbo].[vwUserInvoices] AS
SELECT dbo.AspNetUsers.Id, dbo.AspNetUsers.UserName, dbo.People.FirstName, dbo.People.LastName, dbo.Invoices.TotalAmount, dbo.Invoices.Address, dbo.Invoices.CreationDate
FROM     dbo.AspNetUsers INNER JOIN
                  dbo.Invoices ON dbo.AspNetUsers.Id = dbo.Invoices.UserId INNER JOIN
                  dbo.People ON dbo.AspNetUsers.Id = dbo.People.UserId";
            migrationBuilder.Sql(sql);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1863ee-0adc-4de6-a4d6-9da24a43ce43", "AQAAAAEAACcQAAAAEO22uFsIBPOg+CFvlZI0C7O1fB0rEzkM+HTkks73LNv0LND1+3X5go1KJsoW3/1WBw==", "9e5d4c34-839c-4cd0-b789-f1ad5c8120a6" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 20, 20, 49, 46, 526, DateTimeKind.Local).AddTicks(93));
        }

        protected override void Down(MigrationBuilder migrationBuilder) {

            var sql = @"DROP VIEW [dbo].[vwUserInvoices]";
            migrationBuilder.Sql(sql);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d54fd54-d300-47a8-85e0-25fe0af0a16f", "AQAAAAEAACcQAAAAEI4NvbW9X2aF1dcVrkXw1mAOICdvCr9zH7HDuwtjtjn3C2eU/4OFUrt0dnwBddZF7Q==", "4f0db3b5-4903-4970-8a0d-ffb0e1ad9a82" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 20, 20, 48, 54, 962, DateTimeKind.Local).AddTicks(2222));
        }
    }
}
