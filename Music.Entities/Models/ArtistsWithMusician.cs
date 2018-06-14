using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class ArtistsWithMusician
    {
        public string Artist { get; set; }
        public string Musician { get; set; }
        public short StartDate { get; set; }
        public short EndDate { get; set; }
    }
}
