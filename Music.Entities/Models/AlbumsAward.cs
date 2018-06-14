using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class AlbumsAward
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public short Place { get; set; }
        public short Year { get; set; }
        public virtual Album Album { get; set; }
    }
}
