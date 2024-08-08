using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class nomrandonnee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Randonnee",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Randonnee");
        }
    }
}
