﻿using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Estudiantes
    {
        public Estudiantes()
        {
            BolsaPagos = new HashSet<BolsaPagos>();
            Tutorias = new HashSet<Tutorias>();
        }

        public long IdEstudiantes { get; set; }
        public long UsersIdUser { get; set; }
        public int? Grado { get; set; }
        public string Acudiente { get; set; }
        public long? CelularAcudiente { get; set; }

        public virtual Users UsersIdUserNavigation { get; set; }
        public virtual ICollection<BolsaPagos> BolsaPagos { get; set; }
        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
