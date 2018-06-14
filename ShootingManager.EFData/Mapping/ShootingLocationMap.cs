using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class ShootingLocationMap : EntityTypeConfiguration<ShootingLocation>
    {
        public ShootingLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("ShootingLocation");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
