using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public long IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public long TutoresIdTutores { get; set; }
        public int? Total { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; }
        [Display(Name = "Inicio Periodo")]
        public DateTime? IncioPeriodo { get; set; }
        [Display(Name = "Fin Periodo")]
        public DateTime? FinPeriodo { get; set; }
        [Display(Name = "Total de Horas")]
        public int? TotalHoras { get; set; }

        [Display(Name = "Tutor")]
        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
