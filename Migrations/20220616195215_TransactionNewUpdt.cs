using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpringCoAccountAPI.Migrations
{
    public partial class TransactionNewUpdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountFunded",
                table: "Transaction",
                newName: "AmountDebited");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "AmountDebited",
                table: "Transaction",
                newName: "AmountFunded");
        }
    }
}
