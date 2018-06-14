using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class AlbumsGroup
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public Nullable<short> Rank { get; set; }
        public virtual Album Album { get; set; }
    }
}
