//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bike
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bike()
        {
            this.BenchmarkMiles = new HashSet<BenchmarkMile>();
            this.BikeHistories = new HashSet<BikeHistory>();
            this.BikeOnlyMiles = new HashSet<BikeOnlyMile>();
            this.BikeParts = new HashSet<BikePart>();
            this.BikeParts1 = new HashSet<BikePart>();
            this.Maintenances = new HashSet<Maintenance>();
            this.NonRideMiles = new HashSet<NonRideMile>();
            this.RecreationalRides = new HashSet<RecreationalRide>();
            this.StationaryRides = new HashSet<StationaryRide>();
            this.TrainingRides = new HashSet<TrainingRide>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int TypeId { get; set; }
        public System.DateTime AcquisitionDate { get; set; }
        public int BaseMiles { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BenchmarkMile> BenchmarkMiles { get; set; }
        public virtual BikeType BikeType { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual RouteType RouteType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BikeHistory> BikeHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BikeOnlyMile> BikeOnlyMiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BikePart> BikeParts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BikePart> BikeParts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonRideMile> NonRideMiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecreationalRide> RecreationalRides { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationaryRide> StationaryRides { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingRide> TrainingRides { get; set; }
    }
}
