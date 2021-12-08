using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddProductObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductObjects_TypeObjects_ID",
                        column: x => x.ID,
                        principalTable: "TypeObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfBait",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfBait", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypesOfBait_DictObjects_ID",
                        column: x => x.ID,
                        principalTable: "DictObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfClothing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfClothing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypesOfClothing_DictObjects_ID",
                        column: x => x.ID,
                        principalTable: "DictObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfRod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfRod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypesOfRod_DictObjects_ID",
                        column: x => x.ID,
                        principalTable: "DictObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Baits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeOfBaitID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Baits_ProductObjects_ID",
                        column: x => x.ID,
                        principalTable: "ProductObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baits_TypesOfBait_TypeOfBaitID",
                        column: x => x.TypeOfBaitID,
                        principalTable: "TypesOfBait",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clothings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeOfClothingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clothings_ProductObjects_ID",
                        column: x => x.ID,
                        principalTable: "ProductObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clothings_TypesOfClothing_TypeOfClothingID",
                        column: x => x.TypeOfClothingID,
                        principalTable: "TypesOfClothing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeOfRodID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rods_ProductObjects_ID",
                        column: x => x.ID,
                        principalTable: "ProductObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rods_TypesOfRod_TypeOfRodID",
                        column: x => x.TypeOfRodID,
                        principalTable: "TypesOfRod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baits_TypeOfBaitID",
                table: "Baits",
                column: "TypeOfBaitID");

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_TypeOfClothingID",
                table: "Clothings",
                column: "TypeOfClothingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rods_TypeOfRodID",
                table: "Rods",
                column: "TypeOfRodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baits");

            migrationBuilder.DropTable(
                name: "Clothings");

            migrationBuilder.DropTable(
                name: "Rods");

            migrationBuilder.DropTable(
                name: "TypesOfBait");

            migrationBuilder.DropTable(
                name: "TypesOfClothing");

            migrationBuilder.DropTable(
                name: "ProductObjects");

            migrationBuilder.DropTable(
                name: "TypesOfRod");
        }
    }
}
