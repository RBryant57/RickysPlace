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
    
    public partial class TreadmillRun
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Distance { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int RunTimeHours { get; set; }
        public int RunTimeMinutes { get; set; }
        public int RunTimeSeconds { get; set; }
        public int AverageHR { get; set; }
        public int MaxHR { get; set; }
        public int ElevationGain { get; set; }
        public int ShoeId { get; set; }
        public string Notes { get; set; }
    
        public virtual Shoe Shoe { get; set; }
    }
}
