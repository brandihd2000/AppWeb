using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
   public class Observaciones
    {
        [Key]
        public int idObservaciones { get; set; }

        public int idPaciente { get; set; }
        public Paciente paciente { get; set; }

        public string discapacidad { get; set; }
        public string enfermedades { get; set; }
        public string alergias { get; set; }
        public string medicamentos { get; set; }
       

    }
}
