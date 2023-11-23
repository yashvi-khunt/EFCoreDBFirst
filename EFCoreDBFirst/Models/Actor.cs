using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class Actor
    {
        public int ActId { get; set; }
        public string? ActFname { get; set; }
        public string? ActLname { get; set; }
        public string? ActGender { get; set; }
    }
}
