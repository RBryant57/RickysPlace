using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class Label
    {
        public Label()
        {
            this.Albums = new List<Album>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
