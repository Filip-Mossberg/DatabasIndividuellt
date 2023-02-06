using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Personal
    {
        public Personal()
        {
            PersonalClasses = new HashSet<PersonalClass>();
            Pssgs = new HashSet<Pssg>();
        }

        public int PersonalId { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProffessionId { get; set; }
        public decimal Salary { get; set; }
        public int SectionId { get; set; }
        public DateTime DateHierd { get; set; }

        public virtual Proffession Proffession { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;
        public virtual ICollection<PersonalClass> PersonalClasses { get; set; }
        public virtual ICollection<Pssg> Pssgs { get; set; }
    }
}
