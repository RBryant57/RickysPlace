using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class AlbumsWithSong
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int TrackNumber { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string GenreName { get; set; }
        public string ReleaseYear { get; set; }
        public string LabelName { get; set; }
    }
}
