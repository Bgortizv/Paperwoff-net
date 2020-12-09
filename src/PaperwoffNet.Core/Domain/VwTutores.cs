using System;
using System.Collections.Generic;

namespace PaperwoffNet.Infrastructure
{
    public partial class VwTutores
    {
        public long IdTutores { get; set; }
        public long UsersIdUser { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Profesion { get; set; }
    }
}
