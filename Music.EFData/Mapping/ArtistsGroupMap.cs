using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class ArtistsGroupMap : EntityTypeConfiguration<ArtistsGroup>
    {
        public ArtistsGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ArtistsGroups");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ArtistId).HasColumnName("ArtistId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Rank).HasColumnName("Rank");

            // Relationships
            this.HasRequired(t => t.Artist)
                .WithMany(t => t.ArtistsGroups)
                .HasForeignKey(d => d.ArtistId);

        }
    }
}
