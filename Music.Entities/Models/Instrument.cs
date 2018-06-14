using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace Music.Entities.Models
{
    public partial class Instrument : IEntity
    {
        public Instrument()
        {
            this.MusiciansInstruments = new List<MusiciansInstrument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<MusiciansInstrument> MusiciansInstruments { get; set; }
        public void Dispose()
        {

        }

    }
}
