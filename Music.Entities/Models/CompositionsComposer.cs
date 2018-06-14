using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class CompositionsComposer
    {
        public int Id { get; set; }
        public int CompositionId { get; set; }
        public int MusicianId { get; set; }
        public virtual Composition Composition { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
