using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class ShootingSessionMap : EntityTypeConfiguration<ShootingSession>
    {
        public ShootingSessionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ShootingSession");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.GunId).HasColumnName("GunId");
            this.Property(t => t.CartridgeId).HasColumnName("CartridgeId");
            this.Property(t => t.Rounds).HasColumnName("Rounds");
            this.Property(t => t.Retention).HasColumnName("Retention");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Cartridge)
                .WithMany(t => t.ShootingSessions)
                .HasForeignKey(d => d.CartridgeId);
            this.HasRequired(t => t.Gun)
                .WithMany(t => t.ShootingSessions)
                .HasForeignKey(d => d.GunId);
            this.HasRequired(t => t.ShootingLocation)
                .WithMany(t => t.ShootingSessions)
                .HasForeignKey(d => d.LocationId);

        }
    }
}
