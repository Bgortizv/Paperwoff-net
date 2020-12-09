using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Virpres
    {
        public Virpres()
        {
            Tutorias = new HashSet<Tutorias>();
        }

        public long IdVirPres { get; set; }
        public string Descrip { get; set; }

        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
