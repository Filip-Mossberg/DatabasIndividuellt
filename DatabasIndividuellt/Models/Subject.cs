using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Pssgs = new HashSet<Pssg>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public string CourseActive { get; set; } = null!;

        public virtual ICollection<Pssg> Pssgs { get; set; }
    }
}
