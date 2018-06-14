using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class AlbumsPAlbumMap : EntityTypeConfiguration<AlbumsPAlbum>
    {
        public AlbumsPAlbumMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AlbumsPAlbum");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.PhysicalAlbumId).HasColumnName("PhysicalAlbumId");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumsPAlbums)
                .HasForeignKey(d => d.AlbumId);
            this.HasRequired(t => t.PhysicalAlbum)
                .WithMany(t => t.AlbumsPAlbums)
                .HasForeignKey(d => d.PhysicalAlbumId);

        }
    }
}
