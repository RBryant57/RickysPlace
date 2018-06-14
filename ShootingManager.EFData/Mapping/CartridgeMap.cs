using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class CartridgeMap : EntityTypeConfiguration<Cartridge>
    {
        public CartridgeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Cartridge");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CartridgeLoadId).HasColumnName("CartridgeLoadId");
            this.Property(t => t.BrassId).HasColumnName("BrassId");
            this.Property(t => t.PrimerId).HasColumnName("PrimerId");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Brass)
                .WithMany(t => t.Cartridges)
                .HasForeignKey(d => d.BrassId);
            this.HasRequired(t => t.CartridgeLoad)
                .WithMany(t => t.Cartridges)
                .HasForeignKey(d => d.CartridgeLoadId);
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Cartridges)
                .HasForeignKey(d => d.ManufacturerId);
            this.HasOptional(t => t.Primer)
                .WithMany(t => t.Cartridges)
                .HasForeignKey(d => d.PrimerId);

        }
    }
}
