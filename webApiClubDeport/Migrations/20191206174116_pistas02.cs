using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiClubDeport.Migrations
{
    public partial class pistas02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pistas_Deportes_DeporteId1",
                table: "Pistas");

            migrationBuilder.DropIndex(
                name: "IX_Pistas_DeporteId1",
                table: "Pistas");

            migrationBuilder.DropColumn(
                name: "DeporteId1",
                table: "Pistas");

            migrationBuilder.AlterColumn<int>(
                name: "DeporteId",
                table: "Pistas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "1b2748a6-b2e1-446f-b7bc-d1bd2bc2499a");

            migrationBuilder.CreateIndex(
                name: "IX_Pistas_DeporteId",
                table: "Pistas",
                column: "DeporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pistas_Deportes_DeporteId",
                table: "Pistas",
                column: "DeporteId",
                principalTable: "Deportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pistas_Deportes_DeporteId",
                table: "Pistas");

            migrationBuilder.DropIndex(
                name: "IX_Pistas_DeporteId",
                table: "Pistas");

            migrationBuilder.AlterColumn<string>(
                name: "DeporteId",
                table: "Pistas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DeporteId1",
                table: "Pistas",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "9620c544-623a-4755-922d-c08cdccbf069");

            migrationBuilder.CreateIndex(
                name: "IX_Pistas_DeporteId1",
                table: "Pistas",
                column: "DeporteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pistas_Deportes_DeporteId1",
                table: "Pistas",
                column: "DeporteId1",
                principalTable: "Deportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
