using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DeviceMaintenances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 19, 51, 46, 396, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 19, 51, 46, 396, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 19, 51, 46, 396, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 19, 51, 46, 396, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 19, 51, 46, 396, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 19, 51, 46, 396, DateTimeKind.Local).AddTicks(9105));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DeviceMaintenances",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 18, 41, 23, 231, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 18, 41, 23, 231, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 18, 41, 23, 231, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 18, 41, 23, 231, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 18, 41, 23, 231, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 18, 41, 23, 231, DateTimeKind.Local).AddTicks(7358));
        }
    }
}
