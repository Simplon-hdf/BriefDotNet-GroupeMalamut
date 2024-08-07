using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class Authentification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MotDePasseHash",
                table: "Randonneur",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "MotDePasseSalt",
                table: "Randonneur",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotDePasseHash",
                table: "Randonneur");

            migrationBuilder.DropColumn(
                name: "MotDePasseSalt",
                table: "Randonneur");
        }
    }
}
