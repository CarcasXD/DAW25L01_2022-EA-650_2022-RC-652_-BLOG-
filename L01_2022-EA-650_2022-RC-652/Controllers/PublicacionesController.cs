using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022_EA_650_2022_RC_652.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2022_EA_650_2022_RC_652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly blogContext _blogContext;
        public PublicacionesController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }
        [HttpGet]
        [Route("MostrarPublicaciones")]
        public IActionResult GetPublicaciones()
        {
            List<publicaciones> listaPublicaciones = (from e in _blogContext.publicaciones select e).ToList();
            if (listaPublicaciones.Count == 0)
            {
                return NotFound();
            }
            return Ok(listaPublicaciones);
        }
        [HttpPost]
        [Route("CrearPublicacion")]
        public IActionResult GuardarPublicacion([FromBody] publicaciones publicaciones)
        {
            try
            {
                _blogContext.publicaciones.Add(publicaciones);
                _blogContext.SaveChanges();
                return Ok(publicaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
