using Microsoft.EntityFrameworkCore.Migrations;

namespace Bourse21.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trx_proprietaires_AcheteurID",
                table: "trx");

            migrationBuilder.DropForeignKey(
                name: "FK_trx_Societes_CIEVendueID",
                table: "trx");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trx",
                table: "trx");

            migrationBuilder.RenameTable(
                name: "trx",
                newName: "transactions");

            migrationBuilder.RenameIndex(
                name: "IX_trx_CIEVendueID",
                table: "transactions",
                newName: "IX_transactions_CIEVendueID");

            migrationBuilder.RenameIndex(
                name: "IX_trx_AcheteurID",
                table: "transactions",
                newName: "IX_transactions_AcheteurID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_proprietaires_AcheteurID",
                table: "transactions",
                column: "AcheteurID",
                principalTable: "proprietaires",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_Societes_CIEVendueID",
                table: "transactions",
                column: "CIEVendueID",
                principalTable: "Societes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_proprietaires_AcheteurID",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_Societes_CIEVendueID",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

            migrationBuilder.RenameTable(
                name: "transactions",
                newName: "trx");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_CIEVendueID",
                table: "trx",
                newName: "IX_trx_CIEVendueID");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_AcheteurID",
                table: "trx",
                newName: "IX_trx_AcheteurID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trx",
                table: "trx",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trx_proprietaires_AcheteurID",
                table: "trx",
                column: "AcheteurID",
                principalTable: "proprietaires",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trx_Societes_CIEVendueID",
                table: "trx",
                column: "CIEVendueID",
                principalTable: "Societes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
