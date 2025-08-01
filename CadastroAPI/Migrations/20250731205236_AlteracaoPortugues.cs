using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoPortugues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "People",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "People",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "Nacionalidade");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "People",
                newName: "DataNascimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "People",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "People",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "Nacionalidade",
                table: "People",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "People",
                newName: "BirthDate");
        }
    }
}
