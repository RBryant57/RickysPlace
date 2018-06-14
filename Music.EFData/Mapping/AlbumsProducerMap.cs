using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Music.Entities.Models;

namespace Music.EFData.Mapping
{
    public class AlbumsProducerMap : EntityTypeConfiguration<AlbumsProducer>
    {
        public AlbumsProducerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AlbumsProducers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.MusiciansInstrumentsId).HasColumnName("MusiciansInstrumentsId");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumsProducers)
                .HasForeignKey(d => d.AlbumId);
            this.HasRequired(t => t.MusiciansInstrument)
                .WithMany(t => t.AlbumsProducers)
                .HasForeignKey(d => d.MusiciansInstrumentsId);

        }
    }
}
