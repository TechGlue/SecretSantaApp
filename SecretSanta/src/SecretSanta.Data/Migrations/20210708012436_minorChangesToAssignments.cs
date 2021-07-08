using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class minorChangesToAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiverId",
                table: "Assignment",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Assignment",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_GiverId",
                table: "Assignment",
                column: "GiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ReceiverId",
                table: "Assignment",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Users_GiverId",
                table: "Assignment",
                column: "GiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Users_ReceiverId",
                table: "Assignment",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Users_GiverId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Users_ReceiverId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_GiverId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_ReceiverId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "GiverId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Assignment");
        }
    }
}
