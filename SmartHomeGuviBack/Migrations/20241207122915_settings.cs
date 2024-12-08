using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class settings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowAudioCommands = table.Column<bool>(type: "bit", nullable: false),
                    AllowEnergyNotify = table.Column<bool>(type: "bit", nullable: false),
                    AllowNotify = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.InsertData(
                table: "SecurityDevices",
                columns: new[] { "SecurityDeviceId", "AlertStatus", "DetectionHistory", "Location", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "Active", "", "Living room", "Off", "Motion detector" },
                    { 2, "Active", " ", "Kitchen", "Off", "Camera" },
                    { 3, "Active", "", "Kitchen", "Off", "Motion detector" },
                    { 4, "Active", "", "Front door", "Off", "Motion detector" },
                    { 5, "Active", "", "Front door", "Off", "Camera" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DeleteData(
                table: "SecurityDevices",
                keyColumn: "SecurityDeviceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SecurityDevices",
                keyColumn: "SecurityDeviceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SecurityDevices",
                keyColumn: "SecurityDeviceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SecurityDevices",
                keyColumn: "SecurityDeviceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SecurityDevices",
                keyColumn: "SecurityDeviceId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 13, 14, 38, 396, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 13, 14, 38, 396, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 13, 14, 38, 396, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 13, 14, 38, 396, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 13, 14, 38, 396, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 7, 13, 14, 38, 396, DateTimeKind.Local).AddTicks(9759));
        }
    }
}
