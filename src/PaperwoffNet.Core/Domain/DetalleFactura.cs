using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class DetalleFactura
    {
        public long IdDetalleFactura { get; set; }
        public long FacturaIdFactura { get; set; }
        public long AsignaturaIdAsignatura { get; set; }
        public int? CantidadHoras { get; set; }
        public int? ValorTotal { get; set; }

        public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; }
        public virtual Factura FacturaIdFacturaNavigation { get; set; }
    }
}
