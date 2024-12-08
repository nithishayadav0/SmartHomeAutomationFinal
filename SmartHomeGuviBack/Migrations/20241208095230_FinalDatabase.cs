using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHomeAutomation.Migrations
{
    /// <inheritdoc />
    public partial class FinalDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Automations",
                keyColumn: "AutomationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Automations",
                keyColumn: "AutomationId",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId1",
                table: "Rooms",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserId1",
                table: "Rooms",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserId1",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserId1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Rooms");

            migrationBuilder.InsertData(
                table: "Automations",
                columns: new[] { "AutomationId", "Action", "DeviceId", "Status", "TimeSchedule", "TriggerEvent" },
                values: new object[,]
                {
                    { 1, "TurnOff", 7, "Completed", new TimeSpan(0, 22, 0, 0, 0), "TimeSchedule" },
                    { 2, "TurnOn", 11, "Completed", new TimeSpan(0, 6, 0, 0, 0), "TimeSchedule" }
                });
        }
    }
}
