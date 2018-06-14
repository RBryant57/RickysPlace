using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class PrimerMap : EntityTypeConfiguration<Primer>
    {
        public PrimerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Primer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PrimerTypeId).HasColumnName("PrimerTypeId");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Primers)
                .HasForeignKey(d => d.ManufacturerId);
            this.HasRequired(t => t.PrimerType)
                .WithMany(t => t.Primers)
                .HasForeignKey(d => d.PrimerTypeId);

        }
    }
}
