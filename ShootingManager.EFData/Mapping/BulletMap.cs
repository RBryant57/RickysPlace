using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BulletMap : EntityTypeConfiguration<Bullet>
    {
        public BulletMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(t => t.Diameter).HasPrecision(7, 3);
            this.Property(t => t.BallisticCoefficient).HasPrecision(7, 3);
            this.Property(t => t.SectionalDensity).HasPrecision(7, 3);
            this.Property(t => t.Length).HasPrecision(7, 3);

            // Table & Column Mappings
            this.ToTable("Bullet");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.BulletTypeId).HasColumnName("BulletTypeId");
            this.Property(t => t.MaterialId).HasColumnName("MaterialId");
            this.Property(t => t.Diameter).HasColumnName("Diameter");
            this.Property(t => t.DiameterUnitId).HasColumnName("DiameterUnitId");
            this.Property(t => t.Mass).HasColumnName("Mass");
            this.Property(t => t.MassUnitId).HasColumnName("MassUnitId");
            this.Property(t => t.SectionalDensity).HasColumnName("SectionalDensity");
            this.Property(t => t.BallisticCoefficient).HasColumnName("BallisticCoefficient");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.LengthUnitId).HasColumnName("LengthUnitId");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.BulletType)
                .WithMany(t => t.Bullets)
                .HasForeignKey(d => d.BulletTypeId);
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Bullets)
                .HasForeignKey(d => d.ManufacturerId);
            this.HasRequired(t => t.Material)
                .WithMany(t => t.Bullets)
                .HasForeignKey(d => d.MaterialId);
            this.HasRequired(t => t.DiameterUnit)
                .WithMany(t => t.DiameterUnitBullets)
                .HasForeignKey(d => d.DiameterUnitId);
            this.HasRequired(t => t.LengthUnit)
                .WithMany(t => t.LengthUnitBullets)
                .HasForeignKey(d => d.LengthUnitId);
            this.HasRequired(t => t.MassUnit)
                .WithMany(t => t.MassUnitBullets)
                .HasForeignKey(d => d.MassUnitId);

        }
    }
}
