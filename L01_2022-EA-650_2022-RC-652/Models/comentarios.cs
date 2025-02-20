using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class comentarios
    {
        [Key]
        public int cometarioId { get; set; }
        public int publicacionId { get; set; }
        public string comentario { get; set; }
        public int usuarioId { get; set; }


    }
}
