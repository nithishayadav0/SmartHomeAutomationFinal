using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class EnergyUsages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyUsages",
                columns: table => new
                {
                    UsageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Consumption = table.Column<double>(type: "float", nullable: false),
                    TimePeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnergyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyUsages", x => x.UsageId);
                    table.ForeignKey(
                        name: "FK_EnergyUsages_Devices_DeviceId",
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
                value: new DateTime(2024, 12, 3, 20, 12, 5, 814, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 20, 12, 5, 814, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 20, 12, 5, 814, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 20, 12, 5, 814, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 20, 12, 5, 814, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 3, 20, 12, 5, 814, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.CreateIndex(
                name: "IX_EnergyUsages_DeviceId",
                table: "EnergyUsages",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyUsages");

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
    }
}
