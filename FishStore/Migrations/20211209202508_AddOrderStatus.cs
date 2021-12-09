using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderStatuses_DictObjects_ID",
                        column: x => x.ID,
                        principalTable: "DictObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BaseObjects",
                column: "ID",
                values: new object[]
                {
                    102,
                    103,
                    104,
                    105
                });

            migrationBuilder.InsertData(
                table: "DictObjects",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 102, "Новый" },
                    { 103, "В обработке" },
                    { 104, "Передан в доставку" },
                    { 105, "Доставлен" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                column: "ID",
                values: new object[]
                {
                    102,
                    103,
                    104,
                    105
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusID",
                table: "Orders",
                column: "OrderStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusID",
                table: "Orders",
                column: "OrderStatusID",
                principalTable: "OrderStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusID",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "DictObjects",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "DictObjects",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "DictObjects",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "DictObjects",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "BaseObjects",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "BaseObjects",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "BaseObjects",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "BaseObjects",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusID",
                table: "Orders");
        }
    }
}
