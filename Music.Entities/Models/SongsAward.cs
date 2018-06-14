using System;
using System.Collections.Generic;

namespace Music.Entities.Models
{
    public partial class SongsAward
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public short Place { get; set; }
        public short Year { get; set; }
        public virtual Song Song { get; set; }
    }
}
