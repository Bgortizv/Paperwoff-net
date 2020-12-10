using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class Disponibilidad
    {
        public long IdDisponibilidad { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? Fecha { get; set; }
        [Display(Name = "Comienza")]
        public TimeSpan? HoraInicio { get; set; }
        [Display(Name = "Finaliza")]
        public TimeSpan? HoraFin { get; set; }
        public long TutoresIdTutores { get; set; }
        [Display(Name = "Tutor")]
        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
    }
}
