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
    [Migration("20241208095230_FinalDatabase")]
    partial class FinalDatabase
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

            modelBuilder.Entity("SmartHomeAutomation.Models.DiagnosticsReport", b =>
                {
                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("BatteryLevel")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ConnectivityStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirmwareVersion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("DeviceId");

                    b.ToTable("DiagnosticsReports");
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

            modelBuilder.Entity("SmartHomeAutomation.Models.GlobalAutomation", b =>
                {
                    b.Property<int>("GlobalAutomationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlobalAutomationId"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<TimeSpan?>("TimeSchedule")
                        .IsRequired()
                        .HasColumnType("time");

                    b.Property<string>("TriggerEvent")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GlobalAutomationId");

                    b.ToTable("GlobalAutomations");
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

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.SecurityDevice", b =>
                {
                    b.Property<int>("SecurityDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SecurityDeviceId"));

                    b.Property<string>("AlertStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetectionHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SecurityDeviceId");

                    b.ToTable("SecurityDevices");

                    b.HasData(
                        new
                        {
                            SecurityDeviceId = 1,
                            AlertStatus = "Active",
                            DetectionHistory = "",
                            Location = "Living room",
                            Status = "Off",
                            Type = "Motion detector"
                        },
                        new
                        {
                            SecurityDeviceId = 2,
                            AlertStatus = "Active",
                            DetectionHistory = " ",
                            Location = "Kitchen",
                            Status = "Off",
                            Type = "Camera"
                        },
                        new
                        {
                            SecurityDeviceId = 3,
                            AlertStatus = "Active",
                            DetectionHistory = "",
                            Location = "Kitchen",
                            Status = "Off",
                            Type = "Motion detector"
                        },
                        new
                        {
                            SecurityDeviceId = 4,
                            AlertStatus = "Active",
                            DetectionHistory = "",
                            Location = "Front door",
                            Status = "Off",
                            Type = "Motion detector"
                        },
                        new
                        {
                            SecurityDeviceId = 5,
                            AlertStatus = "Active",
                            DetectionHistory = "",
                            Location = "Front door",
                            Status = "Off",
                            Type = "Camera"
                        });
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowAudioCommands")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowEnergyNotify")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowNotify")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowAudioCommands = false,
                            AllowEnergyNotify = false,
                            AllowNotify = false
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

            modelBuilder.Entity("SmartHomeAutomation.Models.DiagnosticsReport", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.Device", "Device")
                        .WithOne("DiagnosticsReport")
                        .HasForeignKey("SmartHomeAutomation.Models.DiagnosticsReport", "DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.EnergyUsage", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.Device", "Device")
                        .WithMany("EnergyUsages")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Notification", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Rooms", b =>
                {
                    b.HasOne("SmartHomeAutomation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartHomeAutomation.Models.User", null)
                        .WithMany("Rooms")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Device", b =>
                {
                    b.Navigation("Automations");

                    b.Navigation("DeviceMaintenances");

                    b.Navigation("DiagnosticsReport");

                    b.Navigation("EnergyUsages");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.Rooms", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("SmartHomeAutomation.Models.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}