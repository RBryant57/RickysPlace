using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class PowderMap : EntityTypeConfiguration<Powder>
    {
        public PowderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Powder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.PowderTypeId).HasColumnName("PowderTypeId");
            this.Property(t => t.PowderShapeId).HasColumnName("PowderShapeId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Powders)
                .HasForeignKey(d => d.ManufacturerId);
            this.HasRequired(t => t.PowderShape)
                .WithMany(t => t.Powders)
                .HasForeignKey(d => d.PowderShapeId);
            this.HasRequired(t => t.PowderType)
                .WithMany(t => t.Powders)
                .HasForeignKey(d => d.PowderTypeId);

        }
    }
}
