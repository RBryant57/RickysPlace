using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class AlbumsProducer
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int MusiciansInstrumentsId { get; set; }
        public virtual Album Album { get; set; }
        public virtual MusiciansInstrument MusiciansInstrument { get; set; }
    }
}
