using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class GunMap : EntityTypeConfiguration<Gun>
    {
        public GunMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SerialNumber)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Details)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Gun");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CaliberId).HasColumnName("CaliberId");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.Capacity).HasColumnName("Capacity");
            this.Property(t => t.BarrelLength).HasColumnName("BarrelLength");
            this.Property(t => t.BarrelLengthUnitId).HasColumnName("LengthUnitId");
            this.Property(t => t.GunTypeId).HasColumnName("GunTypeId");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.AcquisitionDate).HasColumnName("AcquisitionDate");
            this.Property(t => t.RetireDate).HasColumnName("RetireDate");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Caliber)
                .WithMany(t => t.Guns)
                .HasForeignKey(d => d.CaliberId);
            this.HasRequired(t => t.GunType)
                .WithMany(t => t.Guns)
                .HasForeignKey(d => d.GunTypeId);
            this.HasRequired(t => t.BarrelLengthUnit)
                .WithMany(t => t.Guns)
                .HasForeignKey(t => t.BarrelLengthUnitId);
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Guns)
                .HasForeignKey(d => d.ManufacturerId);

        }
    }
}
