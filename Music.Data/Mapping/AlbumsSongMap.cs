using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class AlbumsSongMap : EntityTypeConfiguration<AlbumsSong>
    {
        public AlbumsSongMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AlbumsSongs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.SongId).HasColumnName("SongId");
            this.Property(t => t.TrackNumber).HasColumnName("TrackNumber");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumsSongs)
                .HasForeignKey(d => d.AlbumId);
            this.HasRequired(t => t.Song)
                .WithMany(t => t.AlbumsSongs)
                .HasForeignKey(d => d.SongId);

        }
    }
}
