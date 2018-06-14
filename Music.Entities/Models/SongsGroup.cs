using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class SongsGroup
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public string Name { get; set; }
        public Nullable<short> Rank { get; set; }
        public virtual Song Song { get; set; }
    }
}
