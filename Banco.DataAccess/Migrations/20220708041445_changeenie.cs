using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banco.DataAccess.Migrations
{
    public partial class changeenie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "tbl_cliente",
                newName: "Contrasena");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contrasena",
                table: "tbl_cliente",
                newName: "Contraseña");
        }
    }
}
