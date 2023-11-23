using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class Rating
    {
        public int? MovId { get; set; }
        public int? RevId { get; set; }
        public double? RevStars { get; set; }
        public int? NumORatings { get; set; }

        public virtual Movie? Mov { get; set; }
        public virtual Reviewer? Rev { get; set; }
    }
}
