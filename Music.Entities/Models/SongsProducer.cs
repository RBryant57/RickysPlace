using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class SongsProducer
    {
        public int Id { get; set; }
        public int MusiciansInstrumentsId { get; set; }
        public int SongId { get; set; }
        public virtual MusiciansInstrument MusiciansInstrument { get; set; }
        public virtual Song Song { get; set; }
    }
}
