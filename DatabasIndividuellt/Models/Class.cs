using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Class
    {
        public Class()
        {
            PersonalClasses = new HashSet<PersonalClass>();
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public int SectionId { get; set; }

        public virtual Section Section { get; set; } = null!;
        public virtual ICollection<PersonalClass> PersonalClasses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
