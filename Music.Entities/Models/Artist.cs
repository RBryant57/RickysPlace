using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Artist
    {
        public Artist()
        {
            this.ArtistsAwards = new List<ArtistsAward>();
            this.ArtistsGroups = new List<ArtistsGroup>();
            this.ArtistsMusicians = new List<ArtistsMusician>();
            this.SongsArtists = new List<SongsArtist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<ArtistsAward> ArtistsAwards { get; set; }
        public virtual ICollection<ArtistsGroup> ArtistsGroups { get; set; }
        public virtual ICollection<ArtistsMusician> ArtistsMusicians { get; set; }
        public virtual ICollection<SongsArtist> SongsArtists { get; set; }
    }
}
