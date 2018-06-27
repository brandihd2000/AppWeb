using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Tratamiento
    {
        [Key]
        public int idTratamiento { get; set; }

        public int idDiagnostico { get; set; }
        public Diagnostico diagnostico { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string comentario { get; set; }
    }
}
