using System;
using System.Collections.Generic;

namespace DatabasIndividuellt.Models
{
    public partial class PersonalClass
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Personal Personal { get; set; } = null!;
    }
}
