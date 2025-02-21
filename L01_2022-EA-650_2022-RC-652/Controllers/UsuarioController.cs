using L01_2022_EA_650_2022_RC_652.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022_EA_650_2022_RC_652.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2022_EA_650_2022_RC_652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly blogContext _blogContext;
        public UsuarioController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        [Route("MostrarUsuarios")]
        public IActionResult Get()
        {
            List<usuarios> listadousuarios = (from e in _blogContext.usuarios select e).ToList();
            if (listadousuarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadousuarios);
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public IActionResult GuardarUsuario([FromBody] usuarios usuario) 
        {
            try
            {
                _blogContext.usuarios.Add(usuario);
                _blogContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Modificar/{id}")]
        public IActionResult ModificarUsuario(int id, [FromBody] usuarios usuarioModificar) 
        {
            usuarios? usuarioActual = (from e in _blogContext.usuarios
                                       where e.usuarioId == id select e).FirstOrDefault();
            if(usuarioActual == null)
            { return NotFound(); }

            usuarioActual.nombreUsuario = usuarioModificar.nombreUsuario;
            usuarioActual.rolId = usuarioModificar.rolId;
            usuarioActual.clave = usuarioModificar.clave;
            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.apellido = usuarioModificar.apellido;

            _blogContext.Entry(usuarioActual).State = EntityState.Modified;
            _blogContext.SaveChanges();

            return Ok(usuarioModificar);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult eliminarUsuario(int id) 
        {
            usuarios? usuarioeliminado = (from e in _blogContext.usuarios
                                          where e.usuarioId == id
                                          select e).FirstOrDefault();
            if (usuarioeliminado == null)  return NotFound(); 

            _blogContext.usuarios.Attach(usuarioeliminado);
            _blogContext.usuarios.Remove(usuarioeliminado);
            _blogContext.SaveChanges(true);

            return Ok(usuarioeliminado);
        }

    }
}
