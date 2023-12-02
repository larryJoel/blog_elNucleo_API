using Blog_Api_ElNucleo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_Api_ElNucleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatosBlogContext _blogContext;

        public UserController(DatosBlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var ListaUser = await _blogContext.Users.ToListAsync();
            return Ok(ListaUser);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] User user)
        {
            await _blogContext.Users.AddAsync(user);
            await _blogContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult>Editar(int id, [FromBody] User user)
        {
            var res = _blogContext.Users.Find(id);
            if (res == null)
            {
                return BadRequest("No se encuentra el user");
            }
            else
            {
                res.Name = user.Name;
                res.LastName = user.LastName;
                res.UserName = user.UserName;
                res.Email = user.Email;
                res.Password = user.Password;
                res.Image = user.Image;
                res.IdRol = user.IdRol;
                res.Status = user.Status;
                res.Kind = user.Kind;
                res.CreateAt = user.CreateAt;
                res.UpdateAt = user.UpdateAt;
                await _blogContext.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult>Eliminar(int id)
        {
            var res = _blogContext.Users.Find(id);
            if(res ==null)
            {
                return BadRequest("No se encuentra el usuario");
            }
            else
            {
                _blogContext.Users.Remove(res);
                await _blogContext.SaveChangesAsync();
                return Ok(res);

            }
        }
    }
}
