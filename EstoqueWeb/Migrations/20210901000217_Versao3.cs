using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueWeb.Migrations
{
    public partial class Versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    CPF = table.Column<string>(type: "char(14)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_Estado = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco_Referencia = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdUsuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
