using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Tutores
    {
        public Tutores()
        {
            Asignaturaxtutor = new HashSet<Asignaturaxtutor>();
            Disponibilidad = new HashSet<Disponibilidad>();
            Factura = new HashSet<Factura>();
            Tutorias = new HashSet<Tutorias>();
        }

        public long IdTutores { get; set; }
        public long UsersIdUser { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Profesion { get; set; }

        public virtual Users UsersIdUserNavigation { get; set; }
        public virtual ICollection<Asignaturaxtutor> Asignaturaxtutor { get; set; }
        public virtual ICollection<Disponibilidad> Disponibilidad { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
