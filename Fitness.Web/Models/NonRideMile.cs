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
    
    public partial class NonRideMile
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int StartOdometer { get; set; }
        public int EndOdometer { get; set; }
        public int BikeId { get; set; }
        public string Notes { get; set; }
    
        public virtual Bike Bike { get; set; }
    }
}
