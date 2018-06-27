using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
   public class Diagnostico
    {
        [Key]
        public int idDiagnostico { get; set; }

        public int idPaciente { get; set; }
        public Paciente paciente { get; set; }

        public int idUsuario { get; set; }
        public  Usuario usuario { get; set; }


        public string sintomas { get; set; }
        public string enfermedad { get; set; }
        public string especialidad { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
        
    }
}
