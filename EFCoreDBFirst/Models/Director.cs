using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class Director
    {
        public int DirId { get; set; }
        public string? DirFname { get; set; }
        public string? DirLname { get; set; }
    }
}
