using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class Song1Map : EntityTypeConfiguration<Song1>
    {
        public Song1Map()
        {
            // Primary Key
            this.HasKey(t => new { t.SongName, t.ArtistName, t.SongReleaseYear, t.SongRating, t.GenreName, t.CompositionName, t.CompositionCreateYear, t.CompositionGenreName });

            // Properties
            this.Property(t => t.SongName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ArtistName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SongReleaseYear)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.GenreName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CompositionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CompositionCreateYear)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.CompositionGenreName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Songs");
            this.Property(t => t.SongName).HasColumnName("SongName");
            this.Property(t => t.ArtistName).HasColumnName("ArtistName");
            this.Property(t => t.SongReleaseYear).HasColumnName("SongReleaseYear");
            this.Property(t => t.SongRating).HasColumnName("SongRating");
            this.Property(t => t.SongNotes).HasColumnName("SongNotes");
            this.Property(t => t.GenreName).HasColumnName("GenreName");
            this.Property(t => t.CompositionName).HasColumnName("CompositionName");
            this.Property(t => t.CompositionCreateYear).HasColumnName("CompositionCreateYear");
            this.Property(t => t.CompositionGenreName).HasColumnName("CompositionGenreName");
        }
    }
}
