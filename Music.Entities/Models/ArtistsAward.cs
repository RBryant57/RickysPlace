using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class ArtistsAward
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public short Place { get; set; }
        public short Year { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
