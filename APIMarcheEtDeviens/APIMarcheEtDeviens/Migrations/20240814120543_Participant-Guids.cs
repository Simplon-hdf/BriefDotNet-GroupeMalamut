using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class ParticipantGuids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participer_Randonnee_RandonneeId",
                table: "Participer");

            migrationBuilder.DropForeignKey(
                name: "FK_Participer_Randonneur_RandonneurId",
                table: "Participer");

            migrationBuilder.AlterColumn<string>(
                name: "RandonneurId",
                table: "Participer",
                type: "nvarchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RandonneeId",
                table: "Participer",
                type: "nvarchar(128)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participer_Randonnee_RandonneeId",
                table: "Participer",
                column: "RandonneeId",
                principalTable: "Randonnee",
                principalColumn: "RandonneeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participer_Randonneur_RandonneurId",
                table: "Participer",
                column: "RandonneurId",
                principalTable: "Randonneur",
                principalColumn: "RandonneurId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participer_Randonnee_RandonneeId",
                table: "Participer");

            migrationBuilder.DropForeignKey(
                name: "FK_Participer_Randonneur_RandonneurId",
                table: "Participer");

            migrationBuilder.AlterColumn<string>(
                name: "RandonneurId",
                table: "Participer",
                type: "nvarchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "RandonneeId",
                table: "Participer",
                type: "nvarchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)");

            migrationBuilder.AddForeignKey(
                name: "FK_Participer_Randonnee_RandonneeId",
                table: "Participer",
                column: "RandonneeId",
                principalTable: "Randonnee",
                principalColumn: "RandonneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participer_Randonneur_RandonneurId",
                table: "Participer",
                column: "RandonneurId",
                principalTable: "Randonneur",
                principalColumn: "RandonneurId");
        }
    }
}
