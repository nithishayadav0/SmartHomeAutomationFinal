using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class InitaileCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 16, 34, 40, 863, DateTimeKind.Local).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 16, 34, 40, 863, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 16, 34, 40, 863, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 16, 34, 40, 863, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 16, 34, 40, 863, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 16, 34, 40, 863, DateTimeKind.Local).AddTicks(5765));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
