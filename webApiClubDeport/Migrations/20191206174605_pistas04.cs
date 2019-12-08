using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiClubDeport.Migrations
{
    public partial class pistas04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "274c3e91-bf6c-4fd1-a0a3-504ad2edd331");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "c331dd97-6829-41f8-9fec-37ab8e607390");
        }
    }
}
