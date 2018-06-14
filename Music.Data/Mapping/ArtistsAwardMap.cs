using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class ArtistsAwardMap : EntityTypeConfiguration<ArtistsAward>
    {
        public ArtistsAwardMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ArtistsAwards");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ArtistId).HasColumnName("ArtistId");
            this.Property(t => t.Place).HasColumnName("Place");
            this.Property(t => t.Year).HasColumnName("Year");

            // Relationships
            this.HasRequired(t => t.Artist)
                .WithMany(t => t.ArtistsAwards)
                .HasForeignKey(d => d.ArtistId);

        }
    }
}
