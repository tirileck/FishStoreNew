using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddBaseObgects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseObjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DictObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DictObjects_BaseObjects_ID",
                        column: x => x.ID,
                        principalTable: "BaseObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypeObjects_BaseObjects_ID",
                        column: x => x.ID,
                        principalTable: "BaseObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictObjects");

            migrationBuilder.DropTable(
                name: "TypeObjects");

            migrationBuilder.DropTable(
                name: "BaseObjects");
        }
    }
}
