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
        [HttpPut]
        [Route("modificar/{publicacionId}")]
        public IActionResult actualizarPublicacion(int id, [FromBody] publicaciones publicacionActualizar)
        {
            publicaciones? publicacionActual = (from e in _blogContext.publicaciones where e.publicacionId == id select e).FirstOrDefault();

            if (publicacionActual == null) { return NotFound(); }

            publicacionActual.titulo = publicacionActualizar.titulo;
            publicacionActual.descripcion=publicacionActualizar.titulo;
            publicacionActual.usuarioId=publicacionActualizar.usuarioId;

            _blogContext.Entry(publicacionActual).State = EntityState.Modified;
            _blogContext.SaveChanges();

            return Ok(publicacionActual);
        }

        [HttpDelete]
        [Route("eliminar/{publicacionId}")]
        public IActionResult eliminarPublicacion(int id)
        {
            publicaciones? publicaciones = (from e in _blogContext.publicaciones where e.publicacionId == id select e).FirstOrDefault();
            if (publicaciones == null)
            {
                return NotFound();
            }

            _blogContext.publicaciones.Attach(publicaciones);
            _blogContext.publicaciones.Remove(publicaciones);
            _blogContext.SaveChanges();
            return Ok(publicaciones);

        }

        [HttpGet]
        [Route("GetByUsuarioID/{id}")]
        public IActionResult listarPublicacion(int id)
        { 
            var publicacion = (from p in _blogContext.publicaciones
                               join u in _blogContext.usuarios
                               on p.usuarioId equals u.usuarioId
                               where p.usuarioId == id
                               select new
                               {
                                   p.publicacionId,
                                   p.titulo,
                                   p.descripcion,
                                   p.usuarioId,
                               }).ToList();
            if (publicacion == null) { return NotFound(); }

            return Ok(publicacion);
        }
    }
}
