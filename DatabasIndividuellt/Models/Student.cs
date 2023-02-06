using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Student
    {
        public Student()
        {
            Pssgs = new HashSet<Pssg>();
        }

        public int StudentId { get; set; }
        public string Ssn { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual ICollection<Pssg> Pssgs { get; set; }
    }
}
