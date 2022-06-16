using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpringCoAccountAPI.Migrations
{
    public partial class NewUpdtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_CustomerId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerId",
                table: "Account",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                table: "Account",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
