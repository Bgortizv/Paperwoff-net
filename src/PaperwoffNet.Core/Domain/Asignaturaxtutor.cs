using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class Asignaturaxtutor
    {
        public long IdAxT { get; set; }
        public long TutoresIdTutores { get; set; }
        public long AsignaturaIdAsignatura { get; set; }
        public bool? Estado { get; set; }

        [Display(Name = "Asignatura")]
        public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; }
        [Display(Name = "Tutor")]
        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
    }
}
