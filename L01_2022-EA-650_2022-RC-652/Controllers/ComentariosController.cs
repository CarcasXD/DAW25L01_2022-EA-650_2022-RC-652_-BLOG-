using L01_2022_EA_650_2022_RC_652.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2022_EA_650_2022_RC_652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly blogContext _blogContext;
        public ComentariosController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }
        [HttpGet]
        [Route("MostrarComentario")]
        public IActionResult GetComentario()
        {
            List<comentarios> listaComentarios = (from e in _blogContext.comentarios select e).ToList();
            if (listaComentarios.Count == 0)
            {
                return NotFound();
            }
            return Ok(listaComentarios);
        }
        [HttpPost]
        [Route("CrearComentario")]
        public IActionResult GuardarComentario([FromBody] comentarios comentario)
        {
            try
            {
                _blogContext.comentarios.Add(comentario);
                _blogContext.SaveChanges();
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Modificar/{id}")]
        public IActionResult ModificarComentario(int id, [FromBody] comentarios comentarioModificar)
        {
            comentarios? comentarioActual = (from e in _blogContext.comentarios
                                       where e.cometarioId == id
                                       select e).FirstOrDefault();
            if (comentarioActual == null)
            { return NotFound(); }

            comentarioActual.publicacionId = comentarioModificar.publicacionId;
            comentarioActual.comentario = comentarioModificar.comentario;
            comentarioActual.usuarioId = comentarioModificar.usuarioId;

            _blogContext.Entry(comentarioActual).State = EntityState.Modified;
            _blogContext.SaveChanges();

            return Ok(comentarioModificar);
        }
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult eliminarComentario(int id)
        {
            comentarios? comentarioeliminado = (from e in _blogContext.comentarios
                                          where e.cometarioId == id
                                          select e).FirstOrDefault();
            if (comentarioeliminado == null) return NotFound();

            _blogContext.comentarios.Attach(comentarioeliminado);
            _blogContext.comentarios.Remove(comentarioeliminado);
            _blogContext.SaveChanges(true);

            return Ok(comentarioeliminado);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult busquedaIdpublicacion(int id)
        {
            var comentarios = (from e in _blogContext.comentarios
                               join t in _blogContext.publicaciones
                               on e.publicacionId equals t.publicacionId
                               where t.publicacionId == id
                               select new
                               {
                                   t.publicacionId,
                                   e
                               }
                               ).ToList();
            if (comentarios == null)
            {
                return NotFound();
            } 
            return Ok(comentarios);
        }


    }
}
