using Blog_Api_ElNucleo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_Api_ElNucleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DatosBlogContext _context;

        public RolController(DatosBlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var listaRol = await _context.Rols.ToListAsync();
            return Ok(listaRol);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Rol rol)
        {
            await _context.Rols.AddAsync(rol);
            await _context.SaveChangesAsync();
            return Ok(rol);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult>Editar(int id, [FromBody] Rol rol)
        {
            var res = _context.Rols.Find(id);
            if (res == null)
            {
                return BadRequest("No se encuentra el rol");
            }
            else
            {
                res.Rol1 = rol.Rol1;
                res.Descripcion = rol.Descripcion;
                await _context.SaveChangesAsync();
                return Ok(rol);
            }
        }

        [HttpDelete]
        [Route("Delete/id:int")]
        public async Task<IActionResult>Eliminar(int id)
        {
            var res = await _context.Rols.FindAsync(id);
            if(res == null)
            {
                return BadRequest("No se encuentra el rol");
            }
            else
            {
                _context.Rols.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

    }
}
