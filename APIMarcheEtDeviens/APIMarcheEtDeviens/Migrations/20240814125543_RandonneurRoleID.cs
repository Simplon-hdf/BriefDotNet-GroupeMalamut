using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class RandonneurRoleID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randonneur_Role_RoleId",
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
                name: "FK_Randonneur_Role_RoleId",
                table: "Randonneur");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Randonneur",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Randonneur_Role_RoleId",
                table: "Randonneur",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId");
        }
    }
}
