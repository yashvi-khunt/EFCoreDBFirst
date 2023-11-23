using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class Movie
    {
        public int MovId { get; set; }
        public string? MovTitle { get; set; }
        public int? MovYear { get; set; }
        public int? MovTime { get; set; }
        public string? MovLang { get; set; }
        public DateTime? MovDtRel { get; set; }
        public string? MovRelCountry { get; set; }
    }
}
