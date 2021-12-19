using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class giftsTypoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Gifts",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gifts",
                newName: "ID");
        }
    }
}
