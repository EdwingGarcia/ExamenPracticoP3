using ApiTareas.Data;
using ApiTareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public TareaController(ApplicationDBContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Tarea> tareas = await _db.Tarea.ToListAsync();
            return Ok(tareas);
        }


        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            Tarea tarea1 = await _db.Tarea.FirstOrDefaultAsync(x => x.IdTarea == tarea.IdTarea);
            if (tarea1 == null && tarea != null)
            {
                await _db.Tarea.AddAsync(tarea);
                await _db.SaveChangesAsync();
                return Ok(tarea);
            }
            return BadRequest("El objeto no existe");
        }


        [HttpGet(" GetTareaNombreEstado/{Nombre}/{Estado}")]
        public async Task<ActionResult<List<Tarea>>> GetTareaNombreEstado(string Nombre, string Estado)
        {
            var tareas = await _db.Tarea.Where(a => a.Nombre == Nombre || a.Estado==Estado).ToListAsync();

            if (tareas == null || tareas.Count == 0)
            {
                return NotFound("No hay");
            }

            return Ok(tareas);
        }


    }
}
