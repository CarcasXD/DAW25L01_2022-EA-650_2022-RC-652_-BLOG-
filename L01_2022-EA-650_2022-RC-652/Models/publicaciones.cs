using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class publicaciones
    {
        [Key]
        public int publicacionId { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int usuarioId { get; set; }

    }
}
