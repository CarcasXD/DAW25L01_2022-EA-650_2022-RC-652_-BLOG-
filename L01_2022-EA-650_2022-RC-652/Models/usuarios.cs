using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class usuarios
    {
        [Key]
        public int usuarioId { get; set; }
        public int? rolId { get; set; }
        public string nombreUsuario { get; set; }
        public string clave {  get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

    }
}
