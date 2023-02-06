using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class VwSectionAverageSalary
    {
        public string SectionName { get; set; } = null!;
        public decimal? Salary { get; set; }
    }
}
