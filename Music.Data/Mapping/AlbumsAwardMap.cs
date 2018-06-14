using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class AlbumsAwardMap : EntityTypeConfiguration<AlbumsAward>
    {
        public AlbumsAwardMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AlbumsAwards");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.Place).HasColumnName("Place");
            this.Property(t => t.Year).HasColumnName("Year");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumsAwards)
                .HasForeignKey(d => d.AlbumId);

        }
    }
}
