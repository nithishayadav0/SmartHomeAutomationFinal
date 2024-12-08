﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHomeAutomation.Data;

#nullable disable

namespace SmartHomeAutomation.Migrations
{
    [DbContext(typeof(SmartHomeDbContext))]
    [Migration("20241204142537_devicemain")]
    partial class devicemain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartHomeAutomation.Models.Automation", b =>
                {
                    b.Property<int>("AutomationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutomationId"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("TimeSchedule")
                        .HasColumnType("time");

                    b.Property<string>("TriggerEvent")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AutomationId");

                    b.HasIndex("DeviceId");

                    b.ToTable("Automations");

                    b.HasData(
                        new
                        {
                            AutomationId = 1,
                            Action = "TurnOff",
                            DeviceId = 7,
                            Status = "Completed",
                            TimeSchedule = new TimeSpan(0, 22, 0, 0, 0),
                            TriggerEvent = "TimeSchedule"
                        },
                        new
                        {
                            AutomationId = 2,
                            Action = "TurnOn",
                            DeviceId = 11,
                            Status = "Completed",
                            TimeSchedule = new TimeSpan(0, 6, 0, 0, 0),
                            TriggerEvent = "TimeSchedule"
                        });
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<string>("ConfigurationSettings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DeviceId");

                    b.HasIndex("RoomId");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            DeviceId = 1,
                            ConfigurationSettings = "Brightness:100",
                            LastUpdated = new DateTime(2024, 12, 4, 19, 55, 36, 143, DateTimeKind.Local).AddTicks(1486),
                            Location = "Ceiling",
                            Name = "Light",
                            RoomId = 1,
                            Status = "Active",
                            Type = "Light"
                        },
                        new
                        {
                            DeviceId = 2,
                            ConfigurationSettings = "Temperature:72",
                            LastUpdated = new DateTime(2024, 12, 4, 19, 55, 36, 143, DateTimeKind.Local).AddTicks(1512),
                            Location = "Wall",
                            Name = "Thermostat",
                            RoomId = 2,
                            Status = "Active",
                            Type = "Thermostat"
                        },
                        new
                        {
                            DeviceId = 3,
                            ConfigurationSettings = "Speed:3",
                            LastUpdated = new DateTime(2024, 12, 4, 19, 55, 36, 143, DateTimeKind.Local).AddTicks(1517),
                            Location = "Ceiling",
                            Name = "Fan",
                            RoomId = 3,
                            Status = "Inactive",
                            Type = "Fan"
                        },
                        new
                        {
                            DeviceId = 4,
                            ConfigurationSettings = "Brightness:100",
                            LastUpdated = new DateTime(2024, 12, 4, 19, 55, 36, 143, DateTimeKind.Local).AddTicks(1521),
                            Location = "Ceiling",
                            Name = "Fan",
                            RoomId = 1,
                            Status = "Active",
                            Type = "Fan"
                        },
                        new
                        {
                            DeviceId = 5,
                            ConfigurationSettings = "Temperature:72",
                            LastUpdated = new DateTime(2024, 12, 4, 19, 55, 36, 143, DateTimeKind.Local).AddTicks(1526),
                            Location = "Wall",
                            Name = "Microwave",
                            RoomId = 2,
                            Status = "Active",
                            Type = "Microwave"
                        },
                        new
                        {
                            DeviceId = 6,
                            ConfigurationSettings = "Speed:3",
                            LastUpdated = new DateTime(2024, 12, 4, 19, 55, 36, 143, DateTimeKind.Local).AddTicks(1530),
                            Location = "Ceiling",
                            Name = "Light",
                            RoomId = 3,
                            Status = "Inactive",
                            Type = "Light"
                        });
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.DeviceMaintenance", b =>
                {
                    b.Property<int>("MaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenanceId"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("MaintenanceType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceMaintenances");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.EnergyUsage", b =>
                {
                    b.Property<int>("UsageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsageId"));

                    b.Property<double>("Consumption")
                        .HasColumnType("float");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<decimal>("EnergyCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimePeriod")
                        .HasColumnType("datetime2");

                    b.HasKey("UsageId");

                    b.HasIndex("DeviceId");

                    b.ToTable("EnergyUsages");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Rooms", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Floor = 1,
                            Name = "Living Room",
                            RoomType = "Common",
                            UserId = 1,
                            ZoneId = 1
                        },
                        new
                        {
                            RoomId = 2,
                            Floor = 1,
                            Name = "Kitchen",
                            RoomType = "Utility",
                            UserId = 2,
                            ZoneId = 2
                        },
                        new
                        {
                            RoomId = 3,
                            Floor = 2,
                            Name = "Bedroom",
                            RoomType = "Private",
                            UserId = 3,
                            ZoneId = 3
                        });
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Automation", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.Device", "Device")
                        .WithMany("Automations")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Device", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.Rooms", "Room")
                        .WithMany("Devices")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.DeviceMaintenance", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.Device", "Device")
                        .WithMany("DeviceMaintenances")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.EnergyUsage", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Notification", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Device", b =>
                {
                    b.Navigation("Automations");

                    b.Navigation("DeviceMaintenances");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Rooms", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
