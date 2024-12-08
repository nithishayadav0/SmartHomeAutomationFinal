using Microsoft.EntityFrameworkCore;
using SmartHomeAutomation.Models;
using System.Collections.Generic;
using System.Transactions;

namespace SmartHomeAutomation.Data
{
    public class SmartHomeDbContext : DbContext
    {
        public SmartHomeDbContext(DbContextOptions<SmartHomeDbContext> options) : base(options) { }


        //Datasets

        public DbSet<User> Users { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Automation> Automations { get; set; }
        public DbSet<EnergyUsage> EnergyUsages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DeviceMaintenance> DeviceMaintenances { get; set; }
        public DbSet<DiagnosticsReport> DiagnosticsReports { get; set; }
        public DbSet<GlobalAutomation> GlobalAutomations { get; set; }
        public DbSet<SecurityDevice> SecurityDevices { get; set; }
        public DbSet<Settings> Settings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Having one-to many relationship b/w User and Rooms
            modelBuilder.Entity<Rooms>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            //Relation btw devices and rooms
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Room)   
                .WithMany(r => r.Devices)  
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relationship bewteen devices and automations
            modelBuilder.Entity<Device>()
                  .HasMany(d => d.Automations)  
                  .WithOne(a => a.Device)   
                  .HasForeignKey(a => a.DeviceId) 
                  .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Device>()
              .HasMany(d => d.EnergyUsages)  // A device can have many energy usage records
              .WithOne(e => e.Device)       // Each energy usage is associated with one device
              .HasForeignKey(e => e.DeviceId) // Foreign key on EnergyUsage model
              .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
               .HasMany(u => u.Notifications)   // A user can have many notifications
               .WithOne(n => n.User)             // Each notification is related to one user
               .HasForeignKey(n => n.UserId)     // Foreign key in Notification points to User
               .OnDelete(DeleteBehavior.Cascade); 

            //Establishing relation between Device and DeviceMaintenance tables
           modelBuilder.Entity<DeviceMaintenance>()
                .HasOne(dm => dm.Device)
                .WithMany(d => d.DeviceMaintenances)
                .HasForeignKey(dm => dm.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            //Diagnosis report for each device
            modelBuilder.Entity<DiagnosticsReport>(entity =>
            {
                entity.HasKey(dr => dr.DeviceId);

                entity.Property(dr => dr.BatteryLevel)
                    .HasMaxLength(10);

                entity.Property(dr => dr.ConnectivityStatus)
                    .HasMaxLength(20);

                entity.Property(dr => dr.FirmwareVersion)
                    .HasMaxLength(20);

                entity.HasOne(dr => dr.Device)
                    .WithOne(d => d.DiagnosticsReport)
                    .HasForeignKey<DiagnosticsReport>(dr => dr.DeviceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<SecurityDevice>().HasData(
               new SecurityDevice
               {
                   SecurityDeviceId = 1,
                   Type = "Motion detector",
                   Status = "Off",
                   Location = "Living room",
                   DetectionHistory = "",
                   AlertStatus = "Active"
               },
               new SecurityDevice
               {
                   SecurityDeviceId = 2,
                   Type = "Camera",
                   Status = "Off",
                   Location = "Kitchen",
                   DetectionHistory = " ",
                   AlertStatus = "Active"
               },
               new SecurityDevice
               {
                   SecurityDeviceId = 3,
                   Type = "Motion detector",
                   Status = "Off",
                   Location = "Kitchen",
                   DetectionHistory = "",
                   AlertStatus = "Active"
               },
               new SecurityDevice
               {
                   SecurityDeviceId = 4,
                   Type = "Motion detector",
                   Status = "Off",
                   Location = "Front door",
                   DetectionHistory = "",
                   AlertStatus = "Active"
               },
               new SecurityDevice
               {
                   SecurityDeviceId = 5,
                   Type = "Camera",
                   Status = "Off",
                   Location = "Front door",
                   DetectionHistory = "",
                   AlertStatus = "Active"
               }
           );
            modelBuilder.Entity<Settings>().HasData(
               new Settings
               {
                   Id = 1,
                   AllowAudioCommands = false,
                   AllowEnergyNotify = false,
                   AllowNotify = false
               }
           );
        }

    }


}


    

           
        
 




