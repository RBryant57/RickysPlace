using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class CompositionsComposerMap : EntityTypeConfiguration<CompositionsComposer>
    {
        public CompositionsComposerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CompositionsComposers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompositionId).HasColumnName("CompositionId");
            this.Property(t => t.MusicianId).HasColumnName("MusicianId");

            // Relationships
            this.HasRequired(t => t.Composition)
                .WithMany(t => t.CompositionsComposers)
                .HasForeignKey(d => d.CompositionId);
            this.HasRequired(t => t.Musician)
                .WithMany(t => t.CompositionsComposers)
                .HasForeignKey(d => d.MusicianId);

        }
    }
}
