using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;
namespace api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;
    public CategoriaController(ICategoriaService categoria)
    {
        categoriaService = categoria;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] Categoria categoria)
    {
        await categoriaService.save(categoria);
        return Results.Created("Se ha creado con exito!", categoria);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Put(Guid id, [FromBody] Categoria categoria)
    {
        await categoriaService.update(id, categoria);
        return Results.Accepted("Se ha actualizado con exito!", categoria);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(Guid id)
    {
        await categoriaService.delete(id);
        return Results.Accepted("Se ha eliminado la categoria con el id suministrado ", id);
    }


}