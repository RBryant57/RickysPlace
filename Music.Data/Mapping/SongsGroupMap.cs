using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class SongsGroupMap : EntityTypeConfiguration<SongsGroup>
    {
        public SongsGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SongsGroups");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SongId).HasColumnName("SongId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Rank).HasColumnName("Rank");

            // Relationships
            this.HasRequired(t => t.Song)
                .WithMany(t => t.SongsGroups)
                .HasForeignKey(d => d.SongId);

        }
    }
}
