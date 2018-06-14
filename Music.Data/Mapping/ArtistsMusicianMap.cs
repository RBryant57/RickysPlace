using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class ArtistsMusicianMap : EntityTypeConfiguration<ArtistsMusician>
    {
        public ArtistsMusicianMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ArtistsMusicians");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MusicianId).HasColumnName("MusicianId");
            this.Property(t => t.ArtistId).HasColumnName("ArtistId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");

            // Relationships
            this.HasRequired(t => t.Artist)
                .WithMany(t => t.ArtistsMusicians)
                .HasForeignKey(d => d.ArtistId);
            this.HasRequired(t => t.Musician)
                .WithMany(t => t.ArtistsMusicians)
                .HasForeignKey(d => d.MusicianId);

        }
    }
}
