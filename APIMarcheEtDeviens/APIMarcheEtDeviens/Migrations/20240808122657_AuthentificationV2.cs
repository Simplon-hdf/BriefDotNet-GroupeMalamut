using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class AuthentificationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotDePasseHash",
                table: "Randonneur");

            migrationBuilder.DropColumn(
                name: "MotDePasseSalt",
                table: "Randonneur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
