using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class GunsCalibersViewMap : EntityTypeConfiguration<GunsCalibersView>
    {
        public GunsCalibersViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GunId, t.GunName, t.CaliberId, t.CaliberName });

            // Properties
            this.Property(t => t.GunId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GunName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CaliberId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CaliberName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GunsCalibersView");
            this.Property(t => t.GunId).HasColumnName("GunId");
            this.Property(t => t.GunName).HasColumnName("GunName");
            this.Property(t => t.CaliberId).HasColumnName("CaliberId");
            this.Property(t => t.CaliberName).HasColumnName("CaliberName");

        }
    }
}
