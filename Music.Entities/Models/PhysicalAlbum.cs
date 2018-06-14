using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class PhysicalAlbum
    {
        public PhysicalAlbum()
        {
            this.AlbumsPAlbums = new List<AlbumsPAlbum>();
        }

        public int Id { get; set; }
        public short AcquisitionDate { get; set; }
        public string Format { get; set; }
        public string State { get; set; }
        public virtual ICollection<AlbumsPAlbum> AlbumsPAlbums { get; set; }
    }
}
