using Blog_Api_ElNucleo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_Api_ElNucleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DatosBlogContext _context;

        public PostController(DatosBlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var listaPost = await _context.Posts.ToListAsync();
            return Ok(listaPost);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPut]
        [Route("Editar/id: int")]
        public async Task<IActionResult>Editar(int id, [FromBody] Post post)
        {
            var res = _context.Posts.Find(id);
            if (res == null)
            {
                return BadRequest("No existe el post");
            }
            else
            {
                res.Title = post.Title;
                res.Brief = post.Brief;
                res.Contenido   = post.Contenido;
                res.Image = post.Image;
                res.CategoryId = post.CategoryId;
                res.UserId = post.UserId;
                res.Status = post.Status;
                res.CreateAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult>Eliminar(int id)
        {
            var res = await _context.Posts.FindAsync(id);
            if(res == null)
            {
                return BadRequest("No se encuentra el post");
            }
            else
            {
                _context.Posts.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
