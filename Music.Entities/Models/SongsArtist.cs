using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class SongsArtist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public Nullable<int> ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
    }
}
