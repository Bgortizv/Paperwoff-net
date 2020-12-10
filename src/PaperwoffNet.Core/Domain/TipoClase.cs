using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class TipoClase
    {
        public TipoClase()
        {
            Tutorias = new HashSet<Tutorias>();
        }

        public long IdTipoClase { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
