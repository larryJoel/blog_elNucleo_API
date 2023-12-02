using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog_Api_ElNucleo.Models;

namespace Blog_Api_ElNucleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatosBlogContext _dbContext;

        public CategoryController(DatosBlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var ListaCategory = await _dbContext.Categories.ToListAsync();
            return Ok(ListaCategory);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] Category category)
        {
            var res = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return BadRequest("No se encontró la categoria");
            }
            else
            {
                res.Name = category.Name;
                res.Description = category.Description;
                await _dbContext.SaveChangesAsync();
                return Ok(res);

            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _dbContext.Categories.FindAsync(id);
            if (res == null)
            {
                return BadRequest("No existe la categoria");
            }
            _dbContext.Categories.Remove(res);
            await _dbContext.SaveChangesAsync();
            return Ok(res);
        }

    }
}
