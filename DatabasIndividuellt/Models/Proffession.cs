using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class Proffession
    {
        public Proffession()
        {
            Personals = new HashSet<Personal>();
        }

        public int ProffessionId { get; set; }
        public string ProffessionName { get; set; } = null!;

        public virtual ICollection<Personal> Personals { get; set; }
    }
}
