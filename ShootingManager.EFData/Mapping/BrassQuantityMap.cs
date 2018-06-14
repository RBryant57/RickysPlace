using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BrassQuantityMap : EntityTypeConfiguration<BrassQuantity>
    {
        public BrassQuantityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("BrassQuantity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EntityId).HasColumnName("BrassId");
            this.Property(t => t.InventoryTypeId).HasColumnName("InventoryTypeId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.StartQuantity).HasColumnName("StartQuantity");
            this.Property(t => t.EndQuantity).HasColumnName("EndQuantity");
            this.Property(t => t.Change).HasColumnName("Change");
            this.Property(t => t.QuantityUnitId).HasColumnName("UnitId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Brass)
                .WithMany(t => t.BrassQuantities)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.QuantityUnit)
                .WithMany(t => t.BrassQuantities)
                .HasForeignKey(d => d.QuantityUnitId);
            this.HasRequired(t => t.InventoryType)
                .WithMany(t => t.BrassQuantities)
                .HasForeignKey(d => d.InventoryTypeId);

        }
    }
}
