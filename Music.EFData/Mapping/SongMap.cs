using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

using Music.Entities;

namespace Music.EFData.Mapping
{
    public class SongMap : EntityTypeConfiguration<Song>
    {
        public SongMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ReleaseYear)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("Song");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ReleaseYear).HasColumnName("ReleaseYear");
            this.Property(t => t.CompositionId).HasColumnName("CompositionId");
            this.Property(t => t.GenreId).HasColumnName("GenreId");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Composition)
                .WithMany(t => t.Songs)
                .HasForeignKey(d => d.CompositionId);
            this.HasRequired(t => t.Genre)
                .WithMany(t => t.Songs)
                .HasForeignKey(d => d.GenreId);

        }
    }
}
