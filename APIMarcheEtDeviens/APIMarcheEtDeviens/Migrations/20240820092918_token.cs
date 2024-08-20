using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class token : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_Randonneur_Role_RoleId",
                table: "Randonneur");

            migrationBuilder.DropColumn(
                name: "MotDePasse",
                table: "Randonneur");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Randonneur",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Randonneur_Role_RoleId",
                table: "Randonneur",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Randonneur_Role_RoleId",
                table: "Randonneur");

            migrationBuilder.DropColumn(
                name: "MotDePasseHash",
                table: "Randonneur");

            migrationBuilder.DropColumn(
                name: "MotDePasseSalt",
                table: "Randonneur");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Randonneur",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MotDePasse",
                table: "Randonneur",
                type: "longtext",
                nullable: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Randonneur_Role_RoleId",
                table: "Randonneur",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId");
        }
    }
}
