using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Disponibilidad
    {
        public long IdDisponibilidad { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public long TutoresIdTutores { get; set; }

        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
    }
}
