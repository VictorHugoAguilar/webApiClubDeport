using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiClubDeport.Migrations
{
    public partial class Pista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pistas_Deportes_deporteId",
                table: "Pistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Pistas_Pistaid",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "Pistaid",
                table: "Reservas",
                newName: "PistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_Pistaid",
                table: "Reservas",
                newName: "IX_Reservas_PistaId");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "Pistas",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "localizacion",
                table: "Pistas",
                newName: "Localizacion");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "Pistas",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "deporteId",
                table: "Pistas",
                newName: "DeporteId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pistas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pistas_deporteId",
                table: "Pistas",
                newName: "IX_Pistas_DeporteId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "4488be39-24e4-4e96-b86a-acab624c92d8");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pistas_Deportes_DeporteId",
                table: "Pistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Pistas_PistaId",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "PistaId",
                table: "Reservas",
                newName: "Pistaid");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_PistaId",
                table: "Reservas",
                newName: "IX_Reservas_Pistaid");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Pistas",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Localizacion",
                table: "Pistas",
                newName: "localizacion");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Pistas",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "DeporteId",
                table: "Pistas",
                newName: "deporteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pistas",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Pistas_DeporteId",
                table: "Pistas",
                newName: "IX_Pistas_deporteId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                column: "ConcurrencyStamp",
                value: "278b2da3-6cb8-40ed-b50c-10f58d0ba6c1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pistas_Deportes_deporteId",
                table: "Pistas",
                column: "deporteId",
                principalTable: "Deportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Pistas_Pistaid",
                table: "Reservas",
                column: "Pistaid",
                principalTable: "Pistas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
