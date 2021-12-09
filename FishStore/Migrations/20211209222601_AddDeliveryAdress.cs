using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddDeliveryAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryAdress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAdress",
                table: "Users");
        }
    }
}
