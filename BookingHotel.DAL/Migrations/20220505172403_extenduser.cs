using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotel.DAL.Migrations
{
    public partial class extenduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_AspNetUsers_UserId1",
                table: "booking");

            migrationBuilder.DropIndex(
                name: "IX_booking_UserId1",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "booking");

            migrationBuilder.RenameColumn(
                name: "NationalId",
                table: "AspNetUsers",
                newName: "u_national_id");

            migrationBuilder.AlterColumn<string>(
                name: "b_user_id",
                table: "booking",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_booking_b_user_id",
                table: "booking",
                column: "b_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_AspNetUsers_b_user_id",
                table: "booking",
                column: "b_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_AspNetUsers_b_user_id",
                table: "booking");

            migrationBuilder.DropIndex(
                name: "IX_booking_b_user_id",
                table: "booking");

            migrationBuilder.RenameColumn(
                name: "u_national_id",
                table: "AspNetUsers",
                newName: "NationalId");

            migrationBuilder.AlterColumn<int>(
                name: "b_user_id",
                table: "booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "booking",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_booking_UserId1",
                table: "booking",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_AspNetUsers_UserId1",
                table: "booking",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
