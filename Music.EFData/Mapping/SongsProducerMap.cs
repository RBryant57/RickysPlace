using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class SongsProducerMap : EntityTypeConfiguration<SongsProducer>
    {
        public SongsProducerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SongsProducers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MusiciansInstrumentsId).HasColumnName("MusiciansInstrumentsId");
            this.Property(t => t.SongId).HasColumnName("SongId");

            // Relationships
            this.HasRequired(t => t.MusiciansInstrument)
                .WithMany(t => t.SongsProducers)
                .HasForeignKey(d => d.MusiciansInstrumentsId);
            this.HasRequired(t => t.Song)
                .WithMany(t => t.SongsProducers)
                .HasForeignKey(d => d.SongId);

        }
    }
}
