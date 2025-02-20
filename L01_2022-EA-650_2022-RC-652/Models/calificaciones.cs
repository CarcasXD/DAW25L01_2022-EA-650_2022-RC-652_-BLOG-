using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class calificaciones
    {
        [Key]
        public int calificacionId { get; set; }
        public int publicacionId { get; set; }
        public int usuarioId { get; set; }
        public int calificacion { get; set; }
    }
}
