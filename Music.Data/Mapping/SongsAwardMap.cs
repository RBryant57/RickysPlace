using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class SongsAwardMap : EntityTypeConfiguration<SongsAward>
    {
        public SongsAwardMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SongsAwards");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SongId).HasColumnName("SongId");
            this.Property(t => t.Place).HasColumnName("Place");
            this.Property(t => t.Year).HasColumnName("Year");

            // Relationships
            this.HasRequired(t => t.Song)
                .WithMany(t => t.SongsAwards)
                .HasForeignKey(d => d.SongId);

        }
    }
}
