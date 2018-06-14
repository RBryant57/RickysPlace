using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class AlbumsPAlbum
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int PhysicalAlbumId { get; set; }
        public virtual Album Album { get; set; }
        public virtual PhysicalAlbum PhysicalAlbum { get; set; }
    }
}
