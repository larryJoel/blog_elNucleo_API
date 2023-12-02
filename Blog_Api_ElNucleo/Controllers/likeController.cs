using Blog_Api_ElNucleo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_Api_ElNucleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class likeController : ControllerBase
    {
        private readonly DatosBlogContext _blogContext;

        public likeController(DatosBlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            var listaLike = _blogContext.Likes.ToList();
            return Ok(listaLike);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Like like)
        {
            await _blogContext.Likes.AddAsync(like);
            await _blogContext.SaveChangesAsync();
            return Ok(like);
        }

        [HttpPut]
        [Route("Editar/in:int")]
        public async Task<IActionResult>Editar(int id, [FromBody] Like like)
        {
            var res = _blogContext.Likes.Find(id);
            if (res == null)
            {
                return BadRequest("No se encuentra el like");
            }
            else
            {
                res.IdPost = like.IdPost;
                res.PositiveLike = like.PositiveLike;
                res.NegativeLike = like.NegativeLike;
                res.CreateAt = like.CreateAt;
                await _blogContext.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("delete/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = _blogContext.Likes.Find(id);
            if(res == null)
            {
                return BadRequest("No se encuentra el link");
            }
            else
            {
                _blogContext.Likes.Remove(res);
                await _blogContext.SaveChangesAsync();
                return Ok(res);
            }
        }

        //[HttpGet]
        //[Route("LikesPorPost/{id:int}")]
        //public IActionResult LikesPorPost(int id)
        //{
        //    var res = _blogContext.Database.SqlQuery<LikesPorPost>($"exec spCalclikesParaUnPost {id}").ToList();
        //    if (res.Any())
        //    {
        //        var likesResult = res.First(); // Suponiendo que solo hay un resultado
        //        return Ok(new { IdPost = likesResult.Id, LikesPositivos = likesResult.LikesPositivos, LikesNegativos = likesResult.LikesNegativos });
        //        //return Ok(res);

        //    }
        //    else
        //    {
        //        return BadRequest("No hay likes para este Post");
        //    }
        //}
    }
}
