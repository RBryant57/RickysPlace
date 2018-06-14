using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class GunsCalibersMap : EntityTypeConfiguration<GunsCalibers>
    {
        public GunsCalibersMap()
        {
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.GunId)
                .IsRequired();
            this.Property(t => t.CaliberId)
                .IsRequired();

            this.ToTable("GunsCalibers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GunId).HasColumnName("GunId");
            this.Property(t => t.CaliberId).HasColumnName("CaliberId");

            this.HasRequired(t => t.Gun)
                .WithMany(t => t.GunsCalibers)
                .HasForeignKey(d => d.GunId);
            this.HasRequired(t => t.Caliber)
                .WithMany(t => t.GunsCalibers)
                .HasForeignKey(d => d.CaliberId);
        }
    }
}