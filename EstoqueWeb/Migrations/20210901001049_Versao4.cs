using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueWeb.Migrations
{
    public partial class Versao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_CEP",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Estado",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Logradouro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Referencia",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Cliente",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    ClienteModelIdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Referencia = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => new { x.ClienteModelIdUsuario, x.Id });
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteModelIdUsuario",
                        column: x => x.ClienteModelIdUsuario,
                        principalTable: "Cliente",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Cliente",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_CEP",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Estado",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Logradouro",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Numero",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Referencia",
                table: "Cliente",
                type: "TEXT",
                nullable: true);
        }
    }
}
