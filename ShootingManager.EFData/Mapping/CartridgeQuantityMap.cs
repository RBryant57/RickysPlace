using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class CartridgeQuantityMap : EntityTypeConfiguration<CartridgeQuantity>
    {
        public CartridgeQuantityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CartridgeQuantity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EntityId).HasColumnName("CartridgeId");
            this.Property(t => t.InventoryTypeId).HasColumnName("InventoryTypeId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.StartQuantity).HasColumnName("StartQuantity");
            this.Property(t => t.EndQuantity).HasColumnName("EndQuantity");
            this.Property(t => t.Change).HasColumnName("Change");
            this.Property(t => t.QuantityUnitId).HasColumnName("UnitId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Cartridge)
                .WithMany(t => t.CartridgeQuantities)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.QuantityUnit)
                .WithMany(t => t.CartridgeQuantities)
                .HasForeignKey(d => d.QuantityUnitId);
            this.HasRequired(t => t.InventoryType)
                .WithMany(t => t.CartridgeQuantities)
                .HasForeignKey(d => d.InventoryTypeId);

        }
    }
}
