using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Section
    {
        public Section()
        {
            Classes = new HashSet<Class>();
            Personals = new HashSet<Personal>();
        }

        public int SectionId { get; set; }
        public string SectionName { get; set; } = null!;

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Personal> Personals { get; set; }
    }
}
