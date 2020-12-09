using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class Users
    {
        public Users()
        {
            Estudiantes = new HashSet<Estudiantes>();
            Tutores = new HashSet<Tutores>();
            Tutorias = new HashSet<Tutorias>();
        }

        public long IdUser { get; set; }
        public long? Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string EMail { get; set; }
        public long? Celular { get; set; }
        public bool? Estado { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public string Password { get; set; }
        public int RoleIdRole { get; set; }

        public virtual Roles RoleIdRoleNavigation { get; set; }
        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
        public virtual ICollection<Tutores> Tutores { get; set; }
        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
