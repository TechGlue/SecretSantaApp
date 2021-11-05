using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment");

            migrationBuilder.DropTable(
                name: "GroupAssignments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Assignment_Giver_Receiver",
                table: "Assignment");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Giver_Receiver",
                table: "Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Assignment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Assignment",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Giver_Receiver",
                table: "Assignment",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Assignment_Giver_Receiver",
                table: "Assignment",
                column: "Giver_Receiver");

            migrationBuilder.CreateTable(
                name: "GroupAssignments",
                columns: table => new
                {
                    GroupAssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAssignments", x => x.GroupAssignmentId);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Date", "Location", "Name", "Time" },
                values: new object[] { 1, "", "", "Pedro's pizza", "" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Date", "Location", "Name", "Time" },
                values: new object[] { 2, "", "", "Pedro's Diner", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "sussy@gmail.com", "Luis", "Garcia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "sussy@gmail.com", "Jeff", "Kapplan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "sussy@gmail.com", "Terry", "Crews" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
