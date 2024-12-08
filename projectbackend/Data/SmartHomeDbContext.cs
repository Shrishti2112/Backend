using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Models; 
using System.Collections.Generic;

namespace SmartHomeAPI.Data
{
    public class SmartHomeDbContext : DbContext
    {
      
        public DbSet<User> Users { get; set; }

        
        public DbSet<Device> Devices { get; set; }

        
        public DbSet<Automation> Automations { get; set; }

       
        public DbSet<EnergyUsage> EnergyUsage { get; set; }

        
        public DbSet<SecurityDevice> SecurityDevices { get; set; }

        
        public DbSet<Room> Rooms { get; set; }

       
        public DbSet<Zone> Zones { get; set; }

       
        public DbSet<VoiceCommand> VoiceCommands { get; set; }

       
        public DbSet<Preference> Preferences { get; set; }

        
        public DbSet<Notification> Notifications { get; set; }

       
        public DbSet<Report> Reports { get; set; }

        
        public DbSet<DeviceMaintenance> DeviceMaintenance { get; set; }

        
        public SmartHomeDbContext(DbContextOptions<SmartHomeDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<VoiceCommand>()
                .HasKey(vc => vc.CommandId);

            modelBuilder.Entity<VoiceCommand>()
                .HasOne<Device>()
                .WithMany()
                .HasForeignKey(vc => vc.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Preference>()
                .HasKey(p => p.PreferenceId);

            modelBuilder.Entity<Preference>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Notification>()
                .HasKey(n => n.NotificationId);

            
            modelBuilder.Entity<EnergyUsage>()
                .HasKey(e => e.UsageId); 

            modelBuilder.Entity<EnergyUsage>()
                .Property(e => e.EnergyCost)
                .HasColumnType("decimal(18,2)");

           
            modelBuilder.Entity<Room>();
            modelBuilder.Entity<Device>();
            modelBuilder.Entity<Report>()
                .HasKey(r => r.ReportId);

            
            modelBuilder.Entity<DeviceMaintenance>()
                .HasKey(dm => dm.MaintenanceId);

            modelBuilder.Entity<DeviceMaintenance>()
                .HasOne(dm => dm.Device)
                .WithMany()
                .HasForeignKey(dm => dm.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Automation>()
                .HasKey(a => a.AutomationId);

            modelBuilder.Entity<Automation>()
                .HasOne<Device>()
                .WithMany()
                .HasForeignKey(a => a.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

           
            base.OnModelCreating(modelBuilder);
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BT-21052622;Database=SmartHomeDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
