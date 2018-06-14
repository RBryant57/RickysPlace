using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Album
    {
        public Album()
        {
            this.AlbumsAwards = new List<AlbumsAward>();
            this.AlbumsGroups = new List<AlbumsGroup>();
            this.AlbumsPAlbums = new List<AlbumsPAlbum>();
            this.AlbumsProducers = new List<AlbumsProducer>();
            this.AlbumsSongs = new List<AlbumsSong>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime AcquisitionDate { get; set; }
        public string ReleaseYear { get; set; }
        public int LabelId { get; set; }
        public byte Rating { get; set; }
        public string Notes { get; set; }
        public virtual Label Label { get; set; }
        public virtual ICollection<AlbumsAward> AlbumsAwards { get; set; }
        public virtual ICollection<AlbumsGroup> AlbumsGroups { get; set; }
        public virtual ICollection<AlbumsPAlbum> AlbumsPAlbums { get; set; }
        public virtual ICollection<AlbumsProducer> AlbumsProducers { get; set; }
        public virtual ICollection<AlbumsSong> AlbumsSongs { get; set; }
    }
}
