using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Song1
    {
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string SongReleaseYear { get; set; }
        public byte SongRating { get; set; }
        public string SongNotes { get; set; }
        public string GenreName { get; set; }
        public string CompositionName { get; set; }
        public string CompositionCreateYear { get; set; }
        public string CompositionGenreName { get; set; }
    }
}
