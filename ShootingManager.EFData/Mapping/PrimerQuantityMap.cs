using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class PrimerQuantityMap : EntityTypeConfiguration<PrimerQuantity>
    {
        public PrimerQuantityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            // Table & Column Mappings
            this.ToTable("PrimerQuantity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EntityId).HasColumnName("PrimerId");
            this.Property(t => t.InventoryTypeId).HasColumnName("InventoryTypeId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.StartQuantity).HasColumnName("StartQuantity");
            this.Property(t => t.EndQuantity).HasColumnName("EndQuantity");
            this.Property(t => t.Change).HasColumnName("Change");
            this.Property(t => t.QuantityUnitId).HasColumnName("UnitId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Primer)
                .WithMany(t => t.PrimerQuantities)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.InventoryType)
                .WithMany(t => t.PrimerQuantities)
                .HasForeignKey(d => d.InventoryTypeId);
            this.HasRequired(t => t.QuantityUnit)
                .WithMany(t => t.PrimerQuantities)
                .HasForeignKey(d => d.QuantityUnitId);

        }
    }
}
