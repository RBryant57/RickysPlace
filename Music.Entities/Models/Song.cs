using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Song
    {
        public Song()
        {
            this.AlbumsSongs = new List<AlbumsSong>();
            this.SongsArtists = new List<SongsArtist>();
            this.SongsAwards = new List<SongsAward>();
            this.SongsGroups = new List<SongsGroup>();
            this.SongsProducers = new List<SongsProducer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public int CompositionId { get; set; }
        public int GenreId { get; set; }
        public byte Rating { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<AlbumsSong> AlbumsSongs { get; set; }
        public virtual Composition Composition { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<SongsArtist> SongsArtists { get; set; }
        public virtual ICollection<SongsAward> SongsAwards { get; set; }
        public virtual ICollection<SongsGroup> SongsGroups { get; set; }
        public virtual ICollection<SongsProducer> SongsProducers { get; set; }
    }
}
