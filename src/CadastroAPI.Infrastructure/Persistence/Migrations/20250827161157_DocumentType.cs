using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DocumentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "People");
        }
    }
}
