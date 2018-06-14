using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class MusiciansInstrument
    {
        public MusiciansInstrument()
        {
            this.AlbumsProducers = new List<AlbumsProducer>();
            this.SongsProducers = new List<SongsProducer>();
        }

        public int Id { get; set; }
        public int MusicianId { get; set; }
        public short InstrumentId { get; set; }
        public virtual ICollection<AlbumsProducer> AlbumsProducers { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual Musician Musician { get; set; }
        public virtual ICollection<SongsProducer> SongsProducers { get; set; }
    }
}
