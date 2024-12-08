using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Automations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Automations",
                keyColumn: "AutomationId",
                keyValue: 1,
                column: "Status",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "Automations",
                keyColumn: "AutomationId",
                keyValue: 2,
                column: "Status",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 18, 1, 7, 865, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 18, 1, 7, 865, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 18, 1, 7, 865, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 18, 1, 7, 865, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 18, 1, 7, 865, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 18, 1, 7, 865, DateTimeKind.Local).AddTicks(7267));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Automations");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 16, 12, 20, 691, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 16, 12, 20, 691, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 16, 12, 20, 691, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 16, 12, 20, 691, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 16, 12, 20, 691, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 16, 12, 20, 691, DateTimeKind.Local).AddTicks(6215));
        }
    }
}
