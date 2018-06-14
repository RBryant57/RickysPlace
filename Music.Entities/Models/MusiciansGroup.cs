using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class MusiciansGroup
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public Nullable<short> Rank { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
