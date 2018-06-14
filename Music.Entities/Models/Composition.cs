using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Composition
    {
        public Composition()
        {
            this.CompositionsComposers = new List<CompositionsComposer>();
            this.Songs = new List<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateYear { get; set; }
        public int GenreId { get; set; }
        public string Notes { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<CompositionsComposer> CompositionsComposers { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
