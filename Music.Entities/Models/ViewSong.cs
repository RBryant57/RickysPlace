using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class ViewSong
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string SongReleaseYear { get; set; }
        public byte SongRating { get; set; }
        public string SongNotes { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreNotes { get; set; }
        public int CompositionId { get; set; }
        public string CompositionName { get; set; }
        public string CompositionNotes { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
