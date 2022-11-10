using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;
namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService tarea)
    {
        tareaService = tarea;
    }

     [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] Tarea tarea)
    {
       await tareaService.save(tarea);
       return Results.Created("Se ha creado con exito!", tarea);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Put(Guid  id, [FromBody] Tarea tarea)
    {
       await tareaService.update(id,tarea);
       return Results.Accepted("Se ha actualizado con exito!", tarea);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(Guid  id)
    {
       await tareaService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }
}
