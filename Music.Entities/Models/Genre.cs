using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Genre
    {
        public Genre()
        {
            this.Compositions = new List<Composition>();
            this.Songs = new List<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
