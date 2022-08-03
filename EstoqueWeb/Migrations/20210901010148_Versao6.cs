using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueWeb.Migrations
{
    public partial class Versao6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Pedidos_PedidoModelIdPedido",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Referencia",
                table: "Pedido",
                newName: "EnderecoEntrega_Referencia");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Pedido",
                newName: "EnderecoEntrega_Numero");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Pedido",
                newName: "EnderecoEntrega_Logradouro");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Pedido",
                newName: "EnderecoEntrega_Estado");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Pedido",
                newName: "EnderecoEntrega_Complemento");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Pedido",
                newName: "EnderecoEntrega_Cidade");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Pedido",
                newName: "EnderecoEntrega_CEP");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Pedido",
                newName: "EnderecoEntrega_Bairro");

            migrationBuilder.RenameColumn(
                name: "PedidoModelIdPedido",
                table: "Pedido",
                newName: "IdPedido");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Numero",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Logradouro",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Estado",
                table: "Pedido",
                type: "char(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Cidade",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_CEP",
                table: "Pedido",
                type: "char(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(9)");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Bairro",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "IdPedido",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrega",
                table: "Pedido",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Pedido",
                type: "REAL",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_IdCliente",
                table: "Pedido",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_IdCliente",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "DataEntrega",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "DataPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Referencia",
                table: "Pedido",
                newName: "Referencia");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Numero",
                table: "Pedido",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Logradouro",
                table: "Pedido",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Estado",
                table: "Pedido",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Complemento",
                table: "Pedido",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Cidade",
                table: "Pedido",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_CEP",
                table: "Pedido",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega_Bairro",
                table: "Pedido",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "IdPedido",
                table: "Pedido",
                newName: "PedidoModelIdPedido");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pedido",
                type: "char(2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Pedido",
                type: "char(9)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(9)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoModelIdPedido",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataEntrega = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataPedido = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorTotal = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Pedidos_PedidoModelIdPedido",
                table: "Pedido",
                column: "PedidoModelIdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
