using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class AlbumsWithSongMap : EntityTypeConfiguration<AlbumsWithSong>
    {
        public AlbumsWithSongMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AlbumId, t.AlbumName, t.TrackNumber, t.SongName, t.ArtistName, t.GenreName, t.ReleaseYear, t.LabelName });

            // Properties
            this.Property(t => t.AlbumId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AlbumName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TrackNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SongName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ArtistName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.GenreName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ReleaseYear)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.LabelName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AlbumsWithSongs");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.AlbumName).HasColumnName("AlbumName");
            this.Property(t => t.TrackNumber).HasColumnName("TrackNumber");
            this.Property(t => t.SongName).HasColumnName("SongName");
            this.Property(t => t.ArtistName).HasColumnName("ArtistName");
            this.Property(t => t.GenreName).HasColumnName("GenreName");
            this.Property(t => t.ReleaseYear).HasColumnName("ReleaseYear");
            this.Property(t => t.LabelName).HasColumnName("LabelName");
        }
    }
}
