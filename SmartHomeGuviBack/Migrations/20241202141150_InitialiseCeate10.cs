using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class InitialiseCeate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automations",
                columns: table => new
                {
                    AutomationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TriggerEvent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeSchedule = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automations", x => x.AutomationId);
                    table.ForeignKey(
                        name: "FK_Automations_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Automations",
                columns: new[] { "AutomationId", "Action", "DeviceId", "Status", "TimeSchedule", "TriggerEvent" },
                values: new object[,]
                {
                    { 1, "TurnOff", 7, "On", new TimeSpan(0, 22, 0, 0, 0), "TimeSchedule" },
                    { 2, "TurnOn", 11, "Off", new TimeSpan(0, 6, 0, 0, 0), "TimeSchedule" }
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 19, 41, 50, 411, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 19, 41, 50, 411, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 19, 41, 50, 411, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 19, 41, 50, 411, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 19, 41, 50, 411, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 12, 2, 19, 41, 50, 411, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.CreateIndex(
                name: "IX_Automations_DeviceId",
                table: "Automations",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automations");

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
    }
}
