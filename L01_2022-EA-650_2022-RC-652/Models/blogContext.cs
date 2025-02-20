using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2022_EA_650_2022_RC_652.Models
{
    public class blogContext:DbContext
    {
        public blogContext(DbContextOptions<blogContext> options) : base(options)
        {

        }

        public DbSet<roles> roles { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<publicaciones> publicaciones { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
        public DbSet<calificaciones> calificaciones { get; set; }

    }
}
