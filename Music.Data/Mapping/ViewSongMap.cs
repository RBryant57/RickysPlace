using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class ViewSongMap : EntityTypeConfiguration<ViewSong>
    {
        public ViewSongMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SongId, t.SongName, t.SongReleaseYear, t.SongRating, t.GenreId, t.GenreName, t.CompositionId, t.CompositionName, t.Id, t.Name });

            // Properties
            this.Property(t => t.SongId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SongName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SongReleaseYear)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.GenreId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GenreName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CompositionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CompositionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ViewSong");
            this.Property(t => t.SongId).HasColumnName("SongId");
            this.Property(t => t.SongName).HasColumnName("SongName");
            this.Property(t => t.SongReleaseYear).HasColumnName("SongReleaseYear");
            this.Property(t => t.SongRating).HasColumnName("SongRating");
            this.Property(t => t.SongNotes).HasColumnName("SongNotes");
            this.Property(t => t.GenreId).HasColumnName("GenreId");
            this.Property(t => t.GenreName).HasColumnName("GenreName");
            this.Property(t => t.GenreNotes).HasColumnName("GenreNotes");
            this.Property(t => t.CompositionId).HasColumnName("CompositionId");
            this.Property(t => t.CompositionName).HasColumnName("CompositionName");
            this.Property(t => t.CompositionNotes).HasColumnName("CompositionNotes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
