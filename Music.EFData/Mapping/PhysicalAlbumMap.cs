using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class PhysicalAlbumMap : EntityTypeConfiguration<PhysicalAlbum>
    {
        public PhysicalAlbumMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Format)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.State)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PhysicalAlbum");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AcquisitionDate).HasColumnName("AcquisitionDate");
            this.Property(t => t.Format).HasColumnName("Format");
            this.Property(t => t.State).HasColumnName("State");
        }
    }
}
