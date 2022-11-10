using api.Models;
namespace api.Services;
using Microsoft.EntityFrameworkCore;
public class TareaService: ITareaService
{
    TareasContext context;
    public TareaService(TareasContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas.Include(p => p.Categoria);
    }
    public async Task save(Tarea tarea)
    {
        await context.AddAsync(tarea);
        await context.SaveChangesAsync();
    }

    public async Task update(Guid id, Tarea tarea)
    {
        var response =  await context.Tareas.FindAsync(id);
        if (response != null)
        {
            response.TareaId = tarea.TareaId;
            response.CategoriaId = tarea.CategoriaId;
            response.Titulo = tarea.Titulo;
            response.Descripcion = tarea.Descripcion;
            response.PrioridadTarea = tarea.PrioridadTarea;
            response.FechaCreacion = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(Guid id)
    {
        var response = await context.Tareas.FindAsync(id);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }


}

public interface ITareaService
{
IEnumerable<Tarea> Get();
Task save(Tarea tarea);

Task update(Guid id, Tarea tarea);

Task delete(Guid id);

}
