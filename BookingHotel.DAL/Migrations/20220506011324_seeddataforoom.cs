using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotel.DAL.Migrations
{
    public partial class seeddataforoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "room",
                columns: new[] { "r_id", "r_booking_id", "r_b_id", "r_h_id", "r_type" },
                values: new object[,]
                {
                    { 13, null, 1, 1, 1 },
                    { 14, null, 1, 1, 2 },
                    { 15, null, 1, 1, 3 },
                    { 16, null, 2, 1, 1 },
                    { 17, null, 2, 1, 2 },
                    { 18, null, 2, 1, 3 },
                    { 19, null, 1, 2, 1 },
                    { 20, null, 1, 2, 2 },
                    { 21, null, 1, 2, 3 },
                    { 22, null, 2, 2, 1 },
                    { 23, null, 2, 2, 2 },
                    { 24, null, 2, 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "r_id",
                keyValue: 24);
        }
    }
}
