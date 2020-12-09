using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class BolsaPagos
    {
        public long IdBolsaPagos { get; set; }
        public long EstudiantesIdEstudiantes { get; set; }
        public long? TotalAbonos { get; set; }
        public long? TotalDescuentos { get; set; }

        public virtual Estudiantes EstudiantesIdEstudiantesNavigation { get; set; }
    }
}
