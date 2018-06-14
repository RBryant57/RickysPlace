using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class ArtistsMusician
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public int ArtistId { get; set; }
        public short StartDate { get; set; }
        public short EndDate { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
