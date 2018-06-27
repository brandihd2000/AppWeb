using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
   public class Paciente
    {
        [Key]
        public int idPaciente { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string grupoSanguineo { get; set; }
    }
}
