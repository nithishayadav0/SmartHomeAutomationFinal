using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosticsReports",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    BatteryLevel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ConnectivityStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticsReports", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_DiagnosticsReports_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 5, 16, 3, 38, 606, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 5, 16, 3, 38, 606, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 5, 16, 3, 38, 606, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 5, 16, 3, 38, 606, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 5, 16, 3, 38, 606, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 5, 16, 3, 38, 606, DateTimeKind.Local).AddTicks(7974));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticsReports");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 21, 37, 26, 623, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 21, 37, 26, 623, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 21, 37, 26, 623, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 21, 37, 26, 623, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 21, 37, 26, 623, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 4, 21, 37, 26, 623, DateTimeKind.Local).AddTicks(474));
        }
    }
}
