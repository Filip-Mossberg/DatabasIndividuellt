using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class VwPersonalInfo
    {
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public int? YearsWorked { get; set; }
        public string ProffessionName { get; set; } = null!;
    }
}
