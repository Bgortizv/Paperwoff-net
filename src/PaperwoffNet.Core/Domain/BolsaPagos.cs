using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class BolsaPagos
    {
        public long IdBolsaPagos { get; set; }
        [Display(Name = "Estudiante")]
        public long EstudiantesIdEstudiantes { get; set; }
        [Display(Name = "Abonos")]
        public long? TotalAbonos { get; set; }
        [Display(Name = "Pagos")]
        public long? TotalDescuentos { get; set; }

        [Display(Name = "Estudiante")]
        public virtual Estudiantes EstudiantesIdEstudiantesNavigation { get; set; }
    }
}
