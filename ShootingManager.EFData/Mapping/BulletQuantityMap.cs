using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BulletQuantityMap : EntityTypeConfiguration<BulletQuantity>
    {
        public BulletQuantityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("BulletQuantity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EntityId).HasColumnName("BulletId");
            this.Property(t => t.InventoryTypeId).HasColumnName("InventoryTypeId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.StartQuantity).HasColumnName("StartQuantity");
            this.Property(t => t.EndQuantity).HasColumnName("EndQuantity");
            this.Property(t => t.Change).HasColumnName("Change");
            this.Property(t => t.QuantityUnitId).HasColumnName("UnitId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Bullet)
                .WithMany(t => t.BulletQuantities)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.QuantityUnit)
                .WithMany(t => t.BulletQuantities)
                .HasForeignKey(d => d.QuantityUnitId);
            this.HasRequired(t => t.InventoryType)
                .WithMany(t => t.BulletQuantities)
                .HasForeignKey(d => d.InventoryTypeId);
        }
    }
}
