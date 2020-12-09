using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Tutorias
    {
        public long IdTutorias { get; set; }
        public long UsersIdUser { get; set; }
        public long TutoresIdTutores { get; set; }
        public long AsignaturaIdAsignatura { get; set; }
        public long EstudiantesIdEstudiantes { get; set; }
        public long TipoClaseIdTipoClase { get; set; }
        public long VirPresIdVirPres { get; set; }
        public int? Transporte { get; set; }
        public int? Total { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int? CantidadHoras { get; set; }
        public bool? Paga { get; set; }

        public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; }
        public virtual Estudiantes EstudiantesIdEstudiantesNavigation { get; set; }
        public virtual TipoClase TipoClaseIdTipoClaseNavigation { get; set; }
        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
        public virtual Users UsersIdUserNavigation { get; set; }
        public virtual Virpres VirPresIdVirPresNavigation { get; set; }
    }
}
