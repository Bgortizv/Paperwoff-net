using System;
using System.Collections.Generic;

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
        public DateTime? FechaCreacion { get; set; }
        public DateTime? IncioPeriodo { get; set; }
        public DateTime? FinPeriodo { get; set; }
        public int? TotalHoras { get; set; }

        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
