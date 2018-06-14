using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Musician
    {
        public Musician()
        {
            this.ArtistsMusicians = new List<ArtistsMusician>();
            this.CompositionsComposers = new List<CompositionsComposer>();
            this.MusiciansGroups = new List<MusiciansGroup>();
            this.MusiciansInstruments = new List<MusiciansInstrument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<ArtistsMusician> ArtistsMusicians { get; set; }
        public virtual ICollection<CompositionsComposer> CompositionsComposers { get; set; }
        public virtual ICollection<MusiciansGroup> MusiciansGroups { get; set; }
        public virtual ICollection<MusiciansInstrument> MusiciansInstruments { get; set; }
    }
}
