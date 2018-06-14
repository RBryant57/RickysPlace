using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.Data.Mapping
{
    public class MusiciansWithInstrumentMap : EntityTypeConfiguration<MusiciansWithInstrument>
    {
        public MusiciansWithInstrumentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Musician, t.Instrument });

            // Properties
            this.Property(t => t.Musician)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Instrument)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MusiciansWithInstruments");
            this.Property(t => t.Musician).HasColumnName("Musician");
            this.Property(t => t.Instrument).HasColumnName("Instrument");
        }
    }
}
