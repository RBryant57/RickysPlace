using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class MusiciansInstrumentMap : EntityTypeConfiguration<MusiciansInstrument>
    {
        public MusiciansInstrumentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MusiciansInstruments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MusicianId).HasColumnName("MusicianId");
            this.Property(t => t.InstrumentId).HasColumnName("InstrumentId");

            // Relationships
            this.HasRequired(t => t.Instrument)
                .WithMany(t => t.MusiciansInstruments)
                .HasForeignKey(d => d.InstrumentId);
            this.HasRequired(t => t.Musician)
                .WithMany(t => t.MusiciansInstruments)
                .HasForeignKey(d => d.MusicianId);

        }
    }
}
