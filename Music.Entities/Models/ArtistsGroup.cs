using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class ArtistsGroup
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public Nullable<short> Rank { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
