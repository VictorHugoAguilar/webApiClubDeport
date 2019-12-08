using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiClubDeport.Migrations
{
    public partial class pistas01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "9620c544-623a-4755-922d-c08cdccbf069");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "e7de2365-b9ef-493a-9a1c-9026591efedd");
        }
    }
}
