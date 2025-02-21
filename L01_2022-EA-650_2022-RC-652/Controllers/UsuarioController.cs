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
    }
}
