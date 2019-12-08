using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiClubDeport.Migrations
{
    public partial class pistas03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "c331dd97-6829-41f8-9fec-37ab8e607390");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "1b2748a6-b2e1-446f-b7bc-d1bd2bc2499a");
        }
    }
}
