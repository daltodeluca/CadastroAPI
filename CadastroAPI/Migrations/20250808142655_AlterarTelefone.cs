using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterarTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "People",
                newName: "Telefone");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long));
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "People",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "People",
                newName: "Numero");
        }

    }
}
