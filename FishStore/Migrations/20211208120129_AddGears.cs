using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddGears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfGear",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfGear", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypesOfGear_DictObjects_ID",
                        column: x => x.ID,
                        principalTable: "DictObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeOfGearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gears_ProductObjects_ID",
                        column: x => x.ID,
                        principalTable: "ProductObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gears_TypesOfGear_TypeOfGearID",
                        column: x => x.TypeOfGearID,
                        principalTable: "TypesOfGear",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gears_TypeOfGearID",
                table: "Gears",
                column: "TypeOfGearID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "TypesOfGear");
        }
    }
}
