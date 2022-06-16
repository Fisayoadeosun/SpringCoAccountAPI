using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpringCoAccountAPI.Migrations
{
    public partial class CustUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piggy_Customer_CustomerId1",
                table: "Piggy");

            migrationBuilder.DropIndex(
                name: "IX_Piggy_CustomerId1",
                table: "Piggy");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Piggy");

            migrationBuilder.DropColumn(
                name: "PiggyId",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Piggy_CustomerId",
                table: "Piggy",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piggy_Customer_CustomerId",
                table: "Piggy",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piggy_Customer_CustomerId",
                table: "Piggy");

            migrationBuilder.DropIndex(
                name: "IX_Piggy_CustomerId",
                table: "Piggy");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Piggy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PiggyId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Piggy_CustomerId1",
                table: "Piggy",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Piggy_Customer_CustomerId1",
                table: "Piggy",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
