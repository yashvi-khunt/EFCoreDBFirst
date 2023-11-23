using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class MovieCast
    {
        public int? ActId { get; set; }
        public int? MovId { get; set; }
        public string? Role { get; set; }

        public virtual Actor? Act { get; set; }
        public virtual Movie? Mov { get; set; }
    }
}
