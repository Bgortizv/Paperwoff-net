using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperwoffNet.Infrastructure
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        [Display(Name = "Role Id")]
        public int IdRole { get; set; }
        [Display(Name = "Tipo Role")]
        public string NombreRol { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
