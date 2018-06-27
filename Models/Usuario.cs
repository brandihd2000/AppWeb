using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario{ get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string tipo { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        
 }
}
