using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCode.Data.Migrations
{
    public partial class ExValidacaoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validacaos_Comprovantes_ComprovanteId",
                table: "Validacaos");

            migrationBuilder.DropColumn(
                name: "ValidacaoId",
                table: "Comprovantes");

            migrationBuilder.AddColumn<Guid>(
                name: "ComprovanteId1",
                table: "Validacaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Validacaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Validacaos_ComprovanteId1",
                table: "Validacaos",
                column: "ComprovanteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Validacaos_Comprovantes_ComprovanteId",
                table: "Validacaos",
                column: "ComprovanteId",
                principalTable: "Comprovantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Validacaos_Comprovantes_ComprovanteId1",
                table: "Validacaos",
                column: "ComprovanteId1",
                principalTable: "Comprovantes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validacaos_Comprovantes_ComprovanteId",
                table: "Validacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Validacaos_Comprovantes_ComprovanteId1",
                table: "Validacaos");

            migrationBuilder.DropIndex(
                name: "IX_Validacaos_ComprovanteId1",
                table: "Validacaos");

            migrationBuilder.DropColumn(
                name: "ComprovanteId1",
                table: "Validacaos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Validacaos");

            migrationBuilder.AddColumn<Guid>(
                name: "ValidacaoId",
                table: "Comprovantes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Validacaos_Comprovantes_ComprovanteId",
                table: "Validacaos",
                column: "ComprovanteId",
                principalTable: "Comprovantes",
                principalColumn: "Id");
        }
    }
}
