//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShootingManager.DataEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class BulletCost
    {
        public int Id { get; set; }
        public int BulletId { get; set; }
        public System.DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
    
        public virtual Bullet Bullet { get; set; }
        public virtual Unit Unit { get; set; }
    }
}