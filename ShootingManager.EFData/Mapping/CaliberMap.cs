using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class CaliberMap : EntityTypeConfiguration<Caliber>
    {
        public CaliberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.Diameter).HasPrecision(7, 3);

            // Table & Column Mappings
            this.ToTable("Caliber");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Diameter).HasColumnName("Diameter");
            this.Property(t => t.DiameterUnitId).HasColumnName("DiameterUnitId");
            this.Property(t => t.BrassLength).HasColumnName("BrassLength");
            this.Property(t => t.BrassLengthUnitId).HasColumnName("BrassLengthUnitId");
            this.Property(t => t.PrimerTypeId).HasColumnName("PrimerTypeId");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.PrimerType)
                .WithMany(t => t.Calibers)
                .HasForeignKey(d => d.PrimerTypeId);
            this.HasRequired(t => t.DiameterUnit)
                .WithMany(t => t.DiameterUnitCalibers)
                .HasForeignKey(d => d.DiameterUnitId);
            this.HasRequired(t => t.BrassLengthUnit)
                .WithMany(t => t.BrassLengthUnitCalibers)
                .HasForeignKey(d => d.BrassLengthUnitId);

        }
    }
}
