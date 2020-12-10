using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Comienza")]
        public TimeSpan HoraInicio { get; set; }
        [Display(Name = "Termina")]
        public TimeSpan HoraFin { get; set; }
        [Display(Name = "Total Horas")]
        public int? CantidadHoras { get; set; }
        public bool? Paga { get; set; }

        [Display(Name = "Asignatura")]
        public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; }
        [Display(Name = "Estudiante")]
        public virtual Estudiantes EstudiantesIdEstudiantesNavigation { get; set; }
        [Display(Name = "Tipo de clase")]
        public virtual TipoClase TipoClaseIdTipoClaseNavigation { get; set; }
        [Display(Name = "Tutor")]
        public virtual Tutores TutoresIdTutoresNavigation { get; set; }
        [Display(Name = "Creada por")]
        public virtual Users UsersIdUserNavigation { get; set; }
        [Display(Name = "Virtual/Presencial")]
        public virtual Virpres VirPresIdVirPresNavigation { get; set; }
    }
}
