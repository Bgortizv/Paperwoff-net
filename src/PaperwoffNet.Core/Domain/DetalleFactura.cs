using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class DetalleFactura
    {
        public long IdDetalleFactura { get; set; }
        public long FacturaIdFactura { get; set; }
        public long AsignaturaIdAsignatura { get; set; }
        [Display(Name = "Cantidad de Horas")]
        public int? CantidadHoras { get; set; }
        [Display(Name = "Valor Total")]
        public int? ValorTotal { get; set; }

        [Display(Name = "Asignatura")]
        public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; }
        [Display(Name = "Id Factura")]
        public virtual Factura FacturaIdFacturaNavigation { get; set; }
    }
}
