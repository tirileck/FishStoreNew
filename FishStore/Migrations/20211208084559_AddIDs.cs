using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baits_TypesOfBait_TypeOfBaitID",
                table: "Baits");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_TypesOfClothing_TypeOfClothingID",
                table: "Clothings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rods_TypesOfRod_TypeOfRodID",
                table: "Rods");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfRodID",
                table: "Rods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfClothingID",
                table: "Clothings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfBaitID",
                table: "Baits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baits_TypesOfBait_TypeOfBaitID",
                table: "Baits",
                column: "TypeOfBaitID",
                principalTable: "TypesOfBait",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_TypesOfClothing_TypeOfClothingID",
                table: "Clothings",
                column: "TypeOfClothingID",
                principalTable: "TypesOfClothing",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rods_TypesOfRod_TypeOfRodID",
                table: "Rods",
                column: "TypeOfRodID",
                principalTable: "TypesOfRod",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baits_TypesOfBait_TypeOfBaitID",
                table: "Baits");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_TypesOfClothing_TypeOfClothingID",
                table: "Clothings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rods_TypesOfRod_TypeOfRodID",
                table: "Rods");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfRodID",
                table: "Rods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfClothingID",
                table: "Clothings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfBaitID",
                table: "Baits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Baits_TypesOfBait_TypeOfBaitID",
                table: "Baits",
                column: "TypeOfBaitID",
                principalTable: "TypesOfBait",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_TypesOfClothing_TypeOfClothingID",
                table: "Clothings",
                column: "TypeOfClothingID",
                principalTable: "TypesOfClothing",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rods_TypesOfRod_TypeOfRodID",
                table: "Rods",
                column: "TypeOfRodID",
                principalTable: "TypesOfRod",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
