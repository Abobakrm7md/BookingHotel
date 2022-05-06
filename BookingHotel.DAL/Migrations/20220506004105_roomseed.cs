using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotel.DAL.Migrations
{
    public partial class roomseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "room",
                columns: new[] { "r_id", "r_booking_id", "r_b_id", "r_h_id", "r_type" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 1 },
                    { 2, null, 1, 1, 2 },
                    { 3, null, 1, 1, 3 },
                    { 4, null, 2, 1, 1 },
                    { 5, null, 2, 1, 2 },
                    { 6, null, 2, 1, 3 },
                    { 7, null, 1, 2, 1 },
                    { 8, null, 1, 2, 2 },
                    { 9, null, 1, 2, 3 },
                    { 10, null, 2, 2, 1 },
                    { 11, null, 2, 2, 2 },
                    { 12, null, 2, 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 12);
        }
    }
}
