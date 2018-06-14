using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BrassCostMap : EntityTypeConfiguration<BrassCost>
    {
        public BrassCostMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("BrassCost");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EntityId).HasColumnName("BrassId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.QuantityUnitId).HasColumnName("UnitId");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Brass)
                .WithMany(t => t.BrassCosts)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.QuantityUnit)
                .WithMany(t => t.BrassCosts)
                .HasForeignKey(d => d.QuantityUnitId);

        }
    }
}
