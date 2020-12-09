using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Asignaturaxtutor
    {
        public long IdAxT { get; set; }
        public long TutoresIdTutores { get; set; }
        public long AsignaturaIdAsignatura { get; set; }
        public bool? Estado { get; set; }

        public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; }
        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
    }
}
