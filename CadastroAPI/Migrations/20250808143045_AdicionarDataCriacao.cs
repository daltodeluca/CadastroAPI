using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDataCriacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
            name: "DataCriacao",
            table: "People",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(2025, 1, 1));

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
