using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotel.DAL.Migrations
{
    public partial class confgrebranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_hotel_HotelId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_room_Branch_r_b_id",
                table: "room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "branch");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "branch",
                newName: "b_name");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "branch",
                newName: "b_h_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "branch",
                newName: "b_id");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_HotelId",
                table: "branch",
                newName: "IX_branch_b_h_id");

            migrationBuilder.AlterColumn<string>(
                name: "b_name",
                table: "branch",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelId1",
                table: "branch",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_branch",
                table: "branch",
                column: "b_id");

            migrationBuilder.InsertData(
                table: "hotel",
                columns: new[] { "h_d", "h_name" },
                values: new object[] { 1, "Helton" });

            migrationBuilder.InsertData(
                table: "hotel",
                columns: new[] { "h_d", "h_name" },
                values: new object[] { 2, "ElTahrir" });

            migrationBuilder.InsertData(
                table: "branch",
                columns: new[] { "b_id", "b_h_id", "HotelId1", "b_name" },
                values: new object[,]
                {
                    { 1, 1, null, "Prim Branch" },
                    { 2, 1, null, "secondary Branch" },
                    { 3, 2, null, "Prim Branch" },
                    { 4, 2, null, "secondary Branch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_branch_HotelId1",
                table: "branch",
                column: "HotelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_branch_hotel_b_h_id",
                table: "branch",
                column: "b_h_id",
                principalTable: "hotel",
                principalColumn: "h_d",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_branch_hotel_HotelId1",
                table: "branch",
                column: "HotelId1",
                principalTable: "hotel",
                principalColumn: "h_d",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_room_branch_r_b_id",
                table: "room",
                column: "r_b_id",
                principalTable: "branch",
                principalColumn: "b_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branch_hotel_b_h_id",
                table: "branch");

            migrationBuilder.DropForeignKey(
                name: "FK_branch_hotel_HotelId1",
                table: "branch");

            migrationBuilder.DropForeignKey(
                name: "FK_room_branch_r_b_id",
                table: "room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_branch",
                table: "branch");

            migrationBuilder.DropIndex(
                name: "IX_branch_HotelId1",
                table: "branch");

            migrationBuilder.DeleteData(
                table: "branch",
                keyColumn: "b_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "branch",
                keyColumn: "b_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "branch",
                keyColumn: "b_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "branch",
                keyColumn: "b_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "hotel",
                keyColumn: "h_d",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hotel",
                keyColumn: "h_d",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "HotelId1",
                table: "branch");

            migrationBuilder.RenameTable(
                name: "branch",
                newName: "Branch");

            migrationBuilder.RenameColumn(
                name: "b_name",
                table: "Branch",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "b_h_id",
                table: "Branch",
                newName: "HotelId");

            migrationBuilder.RenameColumn(
                name: "b_id",
                table: "Branch",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_branch_b_h_id",
                table: "Branch",
                newName: "IX_Branch_HotelId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_hotel_HotelId",
                table: "Branch",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "h_d",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_room_Branch_r_b_id",
                table: "room",
                column: "r_b_id",
                principalTable: "Branch",
                principalColumn: "Id");
        }
    }
}
