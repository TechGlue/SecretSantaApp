using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class changedInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Luis's pizza");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Luis's Diner");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "123@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "123@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "123@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pedro's pizza");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pedro's Diner");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "sussy@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "sussy@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "sussy@gmail.com");
        }
    }
}
