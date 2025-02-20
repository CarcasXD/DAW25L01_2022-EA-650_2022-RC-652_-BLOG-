using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class roles
    {
        [Key]
        public int rolId { get; set; }
        public string rol { get; set; }
    }
}
