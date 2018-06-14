using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class ArtistsWithMusicianMap : EntityTypeConfiguration<ArtistsWithMusician>
    {
        public ArtistsWithMusicianMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Artist, t.Musician, t.StartDate, t.EndDate });

            // Properties
            this.Property(t => t.Artist)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Musician)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.StartDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EndDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ArtistsWithMusicians");
            this.Property(t => t.Artist).HasColumnName("Artist");
            this.Property(t => t.Musician).HasColumnName("Musician");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
        }
    }
}
