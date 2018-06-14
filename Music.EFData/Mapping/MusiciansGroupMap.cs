using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class MusiciansGroupMap : EntityTypeConfiguration<MusiciansGroup>
    {
        public MusiciansGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MusiciansGroups");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MusicianId).HasColumnName("MusicianId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Rank).HasColumnName("Rank");

            // Relationships
            this.HasRequired(t => t.Musician)
                .WithMany(t => t.MusiciansGroups)
                .HasForeignKey(d => d.MusicianId);

        }
    }
}
