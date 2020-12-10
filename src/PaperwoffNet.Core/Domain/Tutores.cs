using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Id Tutor")]
        public long IdTutores { get; set; }
        [Display(Name = "Nombre")]
        public long UsersIdUser { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime? FechaIngreso { get; set; }
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }

        [Display(Name = "Nombre")]
        public virtual Users UsersIdUserNavigation { get; set; }
        public virtual ICollection<Asignaturaxtutor> Asignaturaxtutor { get; set; }
        public virtual ICollection<Disponibilidad> Disponibilidad { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
