using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Manufacturer : Entity
    {
        public Manufacturer()
        {
            this.Brasses = new HashSet<Brass>();
            this.Bullets = new HashSet<Bullet>();
            this.Cartridges = new HashSet<Cartridge>();
            this.Guns = new HashSet<Gun>();
            this.GunsBuyers = new HashSet<Gun>();
            this.GunsManufacturers = new HashSet<Gun>();
            this.GunsSellers = new HashSet<Gun>();
            this.Powders = new HashSet<Powder>();
            this.Primers = new HashSet<Primer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string URL { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Brass> Brasses { get; set; }
        public virtual ICollection<Bullet> Bullets { get; set; }
        public virtual ICollection<Cartridge> Cartridges { get; set; }
        public virtual ICollection<Gun> Guns { get; set; }
        public virtual ICollection<Gun> GunsBuyers { get; set; }        
        public virtual ICollection<Gun> GunsManufacturers { get; set; }        
        public virtual ICollection<Gun> GunsSellers { get; set; }        
        public virtual ICollection<Powder> Powders { get; set; }
        public virtual ICollection<Primer> Primers { get; set; }
    }
}
