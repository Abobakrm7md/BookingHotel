using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotel.DAL.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "lookup",
                columns: new[] { "l_id", "l_cost", "l_name" },
                values: new object[] { 1, 50.0, "Single" });

            migrationBuilder.InsertData(
                table: "lookup",
                columns: new[] { "l_id", "l_cost", "l_name" },
                values: new object[] { 2, 30.0, "double" });

            migrationBuilder.InsertData(
                table: "lookup",
                columns: new[] { "l_id", "l_cost", "l_name" },
                values: new object[] { 3, 150.0, "Suit" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "lookup",
                keyColumn: "l_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "lookup",
                keyColumn: "l_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "lookup",
                keyColumn: "l_id",
                keyValue: 3);
        }
    }
}
