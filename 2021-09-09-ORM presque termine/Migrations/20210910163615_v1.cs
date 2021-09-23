using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bourse21.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proprietaires",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Naissance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Liquidite = table.Column<int>(type: "int", nullable: false),
                    VersionImage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proprietaires", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Societes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaisonSociale = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NbActions = table.Column<int>(type: "int", nullable: false),
                    ValeurUnitaire = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VersionImage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societes", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "trx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NbActions = table.Column<int>(type: "int", nullable: false),
                    CoutUnitaire = table.Column<int>(type: "int", nullable: false),
                    DateTrx = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AcheteurID = table.Column<int>(type: "int", nullable: true),
                    CIEVendueID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trx_proprietaires_AcheteurID",
                        column: x => x.AcheteurID,
                        principalTable: "proprietaires",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_Societes_CIEVendueID",
                        column: x => x.CIEVendueID,
                        principalTable: "Societes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_trx_AcheteurID",
                table: "trx",
                column: "AcheteurID");

            migrationBuilder.CreateIndex(
                name: "IX_trx_CIEVendueID",
                table: "trx",
                column: "CIEVendueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trx");

            migrationBuilder.DropTable(
                name: "proprietaires");

            migrationBuilder.DropTable(
                name: "Societes");
        }
    }
}
