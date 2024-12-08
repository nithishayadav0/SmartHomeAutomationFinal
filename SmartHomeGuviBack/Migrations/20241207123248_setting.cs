using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class setting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "DeviceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "Name", "RoomType", "UserId", "ZoneId" },
                values: new object[,]
                {
                    { 1, 1, "Living Room", "Common", 1, 1 },
                    { 2, 1, "Kitchen", "Utility", 2, 2 },
                    { 3, 2, "Bedroom", "Private", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceId", "ConfigurationSettings", "LastUpdated", "Location", "Name", "RoomId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "Brightness:100", new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5505), "Ceiling", "Light", 1, "Active", "Light" },
                    { 2, "Temperature:72", new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5525), "Wall", "Thermostat", 2, "Active", "Thermostat" },
                    { 3, "Speed:3", new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5529), "Ceiling", "Fan", 3, "Inactive", "Fan" },
                    { 4, "Brightness:100", new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5533), "Ceiling", "Fan", 1, "Active", "Fan" },
                    { 5, "Temperature:72", new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5536), "Wall", "Microwave", 2, "Active", "Microwave" },
                    { 6, "Speed:3", new DateTime(2024, 12, 7, 17, 59, 14, 142, DateTimeKind.Local).AddTicks(5539), "Ceiling", "Light", 3, "Inactive", "Light" }
                });
        }
    }
}
