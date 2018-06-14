using System;
using System.Collections.Generic;

namespace ShootingManager.Entities.Models
{
    public partial class UnitView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plural { get; set; }
        public string Abbreviation { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeNotes { get; set; }
        public string Notes { get; set; }
    }
}
