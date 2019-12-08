using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiClubDeport.Migrations
{
    public partial class Pistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pistas_Deportes_DeporteId",
                table: "Pistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Pistas_PistaId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Socios_SocioId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Pistas_DeporteId",
                table: "Pistas");

            migrationBuilder.AlterColumn<int>(
                name: "SocioId",
                table: "Reservas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PistaId",
                table: "Reservas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeporteId",
                table: "Pistas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeporteId1",
                table: "Pistas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "e7de2365-b9ef-493a-9a1c-9026591efedd");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Pistas_PistaId",
                table: "Reservas",
                column: "PistaId",
                principalTable: "Pistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Socios_SocioId",
                table: "Reservas",
                column: "SocioId",
                principalTable: "Socios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pistas_Deportes_DeporteId1",
                table: "Pistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Pistas_PistaId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Socios_SocioId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Pistas_DeporteId1",
                table: "Pistas");

            migrationBuilder.DropColumn(
                name: "DeporteId1",
                table: "Pistas");

            migrationBuilder.AlterColumn<int>(
                name: "SocioId",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PistaId",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DeporteId",
                table: "Pistas",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "4488be39-24e4-4e96-b86a-acab624c92d8");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Pistas_PistaId",
                table: "Reservas",
                column: "PistaId",
                principalTable: "Pistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Socios_SocioId",
                table: "Reservas",
                column: "SocioId",
                principalTable: "Socios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
