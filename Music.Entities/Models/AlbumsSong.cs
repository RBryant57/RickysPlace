using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class AlbumsSong
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
        public int TrackNumber { get; set; }
        public virtual Album Album { get; set; }
        public virtual Song Song { get; set; }
    }
}
