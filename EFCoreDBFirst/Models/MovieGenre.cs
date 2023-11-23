using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class MovieGenre
    {
        public int? GenId { get; set; }
        public int? MovId { get; set; }

        public virtual Genre? Gen { get; set; }
        public virtual Movie? Mov { get; set; }
    }
}
