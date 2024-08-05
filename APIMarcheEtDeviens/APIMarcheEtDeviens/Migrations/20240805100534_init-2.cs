using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Randonnee",
                columns: table => new
                {
                    RandonneeId = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PrixTotal = table.Column<float>(type: "float", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    NombreMaxPersonnes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randonnee", x => x.RandonneeId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaId = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CheminDuMedia = table.Column<string>(type: "longtext", nullable: false),
                    TypeMedia = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NomMedia = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RandonneeId = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_Media_Randonnee_RandonneeId",
                        column: x => x.RandonneeId,
                        principalTable: "Randonnee",
                        principalColumn: "RandonneeId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Randonneur",
                columns: table => new
                {
                    RandonneurId = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randonneur", x => x.RandonneurId);
                    table.ForeignKey(
                        name: "FK_Randonneur_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pensee",
                columns: table => new
                {
                    PenseeId = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    NomDeLaPensee = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ContenuPensee = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MediaId = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensee", x => x.PenseeId);
                    table.ForeignKey(
                        name: "FK_Pensee_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "MediaId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participer",
                columns: table => new
                {
                    ParticiperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RandonneurId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    RandonneeId = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participer", x => x.ParticiperId);
                    table.ForeignKey(
                        name: "FK_Participer_Randonnee_RandonneeId",
                        column: x => x.RandonneeId,
                        principalTable: "Randonnee",
                        principalColumn: "RandonneeId");
                    table.ForeignKey(
                        name: "FK_Participer_Randonneur_RandonneurId",
                        column: x => x.RandonneurId,
                        principalTable: "Randonneur",
                        principalColumn: "RandonneurId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Media_RandonneeId",
                table: "Media",
                column: "RandonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participer_RandonneeId",
                table: "Participer",
                column: "RandonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participer_RandonneurId",
                table: "Participer",
                column: "RandonneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Pensee_MediaId",
                table: "Pensee",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Randonneur_RoleId",
                table: "Randonneur",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participer");

            migrationBuilder.DropTable(
                name: "Pensee");

            migrationBuilder.DropTable(
                name: "Randonneur");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Randonnee");
        }
    }
}
