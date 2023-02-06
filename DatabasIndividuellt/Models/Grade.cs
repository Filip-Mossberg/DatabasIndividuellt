using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Pssgs = new HashSet<Pssg>();
        }

        public int GradeId { get; set; }
        public string GradeLetter { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual ICollection<Pssg> Pssgs { get; set; }
    }
}
