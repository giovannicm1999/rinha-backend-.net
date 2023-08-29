using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rinha_backend.Migrations
{
    /// <inheritdoc />
    public partial class PessoalMigrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "StackList",
                table: "pessoa",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "apelido",
                table: "pessoa",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nascimento",
                table: "pessoa",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "pessoa",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "stack",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_apelido",
                table: "pessoa",
                column: "apelido",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pessoa_apelido",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "StackList",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "apelido",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "nascimento",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "stack",
                table: "pessoa");
        }
    }
}
