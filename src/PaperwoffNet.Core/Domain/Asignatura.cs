using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Asignaturaxtutor = new HashSet<Asignaturaxtutor>();
            DetalleFactura = new HashSet<DetalleFactura>();
            Tutorias = new HashSet<Tutorias>();
        }

        public long IdAsignatura { get; set; }
        [Display(Name = "Asignatura")]
        public string NombreAsignatura { get; set; }
        public int? Código { get; set; }

        public virtual ICollection<Asignaturaxtutor> Asignaturaxtutor { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
