using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class CartridgeLoadMap : EntityTypeConfiguration<CartridgeLoad>
    {
        public CartridgeLoadMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(t => t.COL).HasPrecision(7, 3);

            // Table & Column Mappings
            this.ToTable("CartridgeLoad");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CaliberId).HasColumnName("CaliberId");
            this.Property(t => t.BulletId).HasColumnName("BulletId");
            this.Property(t => t.PowderId).HasColumnName("PowderId");
            this.Property(t => t.PowderWeight).HasColumnName("PowderWeight");
            this.Property(t => t.PowderWeightUnitId).HasColumnName("PowderWeightUnitId");
            this.Property(t => t.COL).HasColumnName("COL");
            this.Property(t => t.COLUnitId).HasColumnName("COLUnitId");
            this.Property(t => t.Velocity).HasColumnName("Velocity");
            this.Property(t => t.VelocityUnitId).HasColumnName("VelocityUnitId");
            this.Property(t => t.Pressure).HasColumnName("Pressure");
            this.Property(t => t.PressureUnitId).HasColumnName("PressureUnitId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Bullet)
                .WithMany(t => t.CartridgeLoads)
                .HasForeignKey(d => d.BulletId);
            this.HasRequired(t => t.Caliber)
                .WithMany(t => t.CartridgeLoads)
                .HasForeignKey(d => d.CaliberId);
            this.HasOptional(t => t.Powder)
                .WithMany(t => t.CartridgeLoads)
                .HasForeignKey(d => d.PowderId);
            this.HasOptional(t => t.PowderWeightUnit)
                .WithMany(t => t.PowderWeightUnitCartridgeLoads)
                .HasForeignKey(d => d.PowderWeightUnitId);
            this.HasRequired(t => t.COLUnit)
                .WithMany(t => t.COLUnitCartridgeLoads)
                .HasForeignKey(d => d.COLUnitId);
            this.HasOptional(t => t.VelocityUnit)
                .WithMany(t => t.VelocityUnitCartridgeLoads)
                .HasForeignKey(d => d.VelocityUnitId);
            this.HasOptional(t => t.PressureUnit)
                .WithMany(t => t.PressureUnitCartridgeLoads)
                .HasForeignKey(d => d.PressureUnitId);

        }
    }
}
