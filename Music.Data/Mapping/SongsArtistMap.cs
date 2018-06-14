using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class SongsArtistMap : EntityTypeConfiguration<SongsArtist>
    {
        public SongsArtistMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SongsArtists");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SongId).HasColumnName("SongId");
            this.Property(t => t.ArtistId).HasColumnName("ArtistId");

            // Relationships
            this.HasOptional(t => t.Artist)
                .WithMany(t => t.SongsArtists)
                .HasForeignKey(d => d.ArtistId);
            this.HasRequired(t => t.Song)
                .WithMany(t => t.SongsArtists)
                .HasForeignKey(d => d.SongId);

        }
    }
}
