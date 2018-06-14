using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class Album1Map : EntityTypeConfiguration<Album1>
    {
        public Album1Map()
        {
            // Primary Key
            this.HasKey(t => new { t.AlbumName, t.YearReleased, t.ArtistName, t.GenreName, t.LabelName });

            // Properties
            this.Property(t => t.AlbumName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.YearReleased)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.ArtistName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.GenreName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LabelName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Albums");
            this.Property(t => t.AlbumName).HasColumnName("AlbumName");
            this.Property(t => t.YearReleased).HasColumnName("YearReleased");
            this.Property(t => t.ArtistName).HasColumnName("ArtistName");
            this.Property(t => t.GenreName).HasColumnName("GenreName");
            this.Property(t => t.LabelName).HasColumnName("LabelName");
        }
    }
}
