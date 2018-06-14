using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class AlbumsGroupMap : EntityTypeConfiguration<AlbumsGroup>
    {
        public AlbumsGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AlbumsGroups");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Rank).HasColumnName("Rank");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumsGroups)
                .HasForeignKey(d => d.AlbumId);

        }
    }
}
