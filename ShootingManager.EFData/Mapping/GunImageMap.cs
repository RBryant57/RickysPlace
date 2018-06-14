using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class GunImageMap : EntityTypeConfiguration<GunImage>
    {
        public GunImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PictureLocation)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("GunImages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GunId).HasColumnName("GunId");
            this.Property(t => t.PictureLocation).HasColumnName("PictureLocation");

            // Relationships
            this.HasRequired(t => t.Gun)
                .WithMany(t => t.GunImages)
                .HasForeignKey(d => d.GunId);

        }
    }
}
