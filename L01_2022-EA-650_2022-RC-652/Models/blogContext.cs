using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class blogContext:DbContext
    {
        public blogContext(DbContextOptions<blogContext> options) : base(options)
        {

        }
    }
}
