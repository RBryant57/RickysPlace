using System;
using System.Collections.Generic;

namespace ShootingManager.Entities.Models
{
    public partial class PowderView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PowderName { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string ManufacturerCity { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerZip { get; set; }
        public string ManufacturerURL { get; set; }
        public string ManufacturerNotes { get; set; }
        public int PowderTypeId { get; set; }
        public string PowderTypeName { get; set; }
        public string PowderTypeNotes { get; set; }
        public int PowderShapeId { get; set; }
        public string PowderShapeName { get; set; }
        public string PowderShapeNotes { get; set; }
        public string Notes { get; set; }
    }
}
