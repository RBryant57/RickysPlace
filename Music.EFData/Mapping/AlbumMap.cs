using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class AlbumMap : EntityTypeConfiguration<Album>
    {
        public AlbumMap()
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

            this.Property(t => t.Notes)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Album");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AcquisitionDate).HasColumnName("AcquisitionDate");
            this.Property(t => t.ReleaseYear).HasColumnName("ReleaseYear");
            this.Property(t => t.LabelId).HasColumnName("LabelId");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Label)
                .WithMany(t => t.Albums)
                .HasForeignKey(d => d.LabelId);

        }
    }
}
