using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class PrimerType : Entity
    {
        public PrimerType()
        {
            this.Calibers = new List<Caliber>();
            this.Primers = new List<Primer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Caliber> Calibers { get; set; }
        public virtual ICollection<Primer> Primers { get; set; }
    }
}
