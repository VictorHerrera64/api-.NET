using api.Models;
namespace api.Services;
public class CategoriaService:ICategoriaService
{
    TareasContext context;
    public CategoriaService(TareasContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }
    public async Task save(Categoria categoria)
    {
        await context.AddAsync(categoria);
        await context.SaveChangesAsync();
    }

    public async Task update(Guid id, Categoria categoria)
    {
        var response = context.Categorias.Find(id);
        if (response != null)
        {
            response.Nombre = categoria.Nombre;
            response.Descripcion = categoria.Descripcion;
            response.Peso = categoria.Peso;
            await context.SaveChangesAsync();
        }
    }

     public async Task delete(Guid id)
    {
        var response = context.Categorias.Find(id);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }


}

public interface ICategoriaService
{
IEnumerable<Categoria> Get();
Task save(Categoria categoria);

Task update(Guid id, Categoria categoria);

Task delete(Guid id);

}