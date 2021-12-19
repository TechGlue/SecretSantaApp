using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class giftsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Users_ReceiverId",
                table: "Gifts");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "Gifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Users_ReceiverId",
                table: "Gifts",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Users_ReceiverId",
                table: "Gifts");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "Gifts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Users_ReceiverId",
                table: "Gifts",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
