using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Rooms_RoomsRoomId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_RoomsRoomId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "RoomsRoomId",
                table: "Devices");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 15, 32, 34, 899, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 15, 32, 34, 899, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 15, 32, 34, 899, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 15, 32, 34, 899, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 15, 32, 34, 899, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 15, 32, 34, 899, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RoomId",
                table: "Devices",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_RoomId",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "RoomsRoomId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                columns: new[] { "LastUpdated", "RoomsRoomId" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 26, 41, 347, DateTimeKind.Local).AddTicks(2329), null });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                columns: new[] { "LastUpdated", "RoomsRoomId" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 26, 41, 347, DateTimeKind.Local).AddTicks(2342), null });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                columns: new[] { "LastUpdated", "RoomsRoomId" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 26, 41, 347, DateTimeKind.Local).AddTicks(2344), null });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                columns: new[] { "LastUpdated", "RoomsRoomId" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 26, 41, 347, DateTimeKind.Local).AddTicks(2346), null });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                columns: new[] { "LastUpdated", "RoomsRoomId" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 26, 41, 347, DateTimeKind.Local).AddTicks(2347), null });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                columns: new[] { "LastUpdated", "RoomsRoomId" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 26, 41, 347, DateTimeKind.Local).AddTicks(2349), null });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RoomsRoomId",
                table: "Devices",
                column: "RoomsRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rooms_RoomsRoomId",
                table: "Devices",
                column: "RoomsRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }
    }
}
