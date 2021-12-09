using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Roles_DictObjects_ID",
                        column: x => x.ID,
                        principalTable: "DictObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BaseObjects",
                column: "ID",
                value: 100);

            migrationBuilder.InsertData(
                table: "BaseObjects",
                column: "ID",
                value: 101);

            migrationBuilder.InsertData(
                table: "DictObjects",
                columns: new[] { "ID", "Name" },
                values: new object[] { 100, "User" });

            migrationBuilder.InsertData(
                table: "DictObjects",
                columns: new[] { "ID", "Name" },
                values: new object[] { 101, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "ID",
                value: 100);

            migrationBuilder.InsertData(
                table: "Roles",
                column: "ID",
                value: 101);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "DictObjects",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "DictObjects",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "BaseObjects",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "BaseObjects",
                keyColumn: "ID",
                keyValue: 101);
        }
    }
}
