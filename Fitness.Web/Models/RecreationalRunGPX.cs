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
    
    public partial class RecreationalRunGPX
    {
        public int Id { get; set; }
        public int RecreationalRunId { get; set; }
        public string GPX { get; set; }
        public string Notes { get; set; }
    
        public virtual RecreationalRun RecreationalRun { get; set; }
    }
}