using Blog_Api_ElNucleo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Api_ElNucleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DatosBlogContext _blogContext;

        public CommentController(DatosBlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Get()
        {
            var listaComment = _blogContext.Comments.ToList();
            return Ok(listaComment);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Comment comment)
        {
            await _blogContext.Comments.AddAsync(comment);
            await _blogContext.SaveChangesAsync();
            return Ok(comment);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult>Editar(int id, [FromBody] Comment comment)
        {
            var res = _blogContext.Comments.Find(id);
            if (res == null)
            {
                return BadRequest("No se encuentra el comentario");
            }
            else
            {
                res.Name = comment.Name;
                res.Email = comment.Email;
                res.Comment1 = comment.Comment1;
                res.PostId = comment.PostId;
                res.Status = comment.Status;
                res.CreateAt = comment.CreateAt;
                res.IdRol= comment.IdRol;
                res.Clave= comment.Clave;
                await _blogContext.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult>Eliminar(int id)
        {
            var res = _blogContext.Comments.Find(id);
            if(res == null)
            {
                return BadRequest("No se encuentra el comentario");
            }
            else
            {
                _blogContext.Comments.Remove(res);
                await _blogContext.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
