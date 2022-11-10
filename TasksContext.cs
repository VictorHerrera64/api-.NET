using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    //models fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoryList = new List<Categoria>();
        categoryList.Add(new Categoria() { CategoriaId = Guid.Parse("6e2703b0-0839-4b6b-b912-285f65f19ddc"), Nombre = "Pending activities", Descripcion = "Tareas que no has hecho", Peso = 20 });
        categoryList.Add(new Categoria() { CategoriaId = Guid.Parse("b94efb76-dc7f-4950-89bb-69e00d38e79e"), Nombre = "Personal activities", Descripcion = "Tareas tuyas", Peso = 50 });
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired().HasMaxLength(300);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoryList);
        });
        List<Tarea> taskList = new List<Tarea>();
        taskList.Add(new Tarea() { TareaId = Guid.Parse("e91326d5-e5ba-40a1-871d-14dfde16cefe"), CategoriaId = Guid.Parse("6e2703b0-0839-4b6b-b912-285f65f19ddc"), Titulo = "Estudiar C#", Descripcion = "Seguir con platzi", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });
        taskList.Add(new Tarea() { TareaId = Guid.Parse("b282b075-dfee-462e-98d7-db2d21ac4c7c"), CategoriaId = Guid.Parse("b94efb76-dc7f-4950-89bb-69e00d38e79e"), Titulo = "Ir al gym", Descripcion = "rutina de torso", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now });
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            // indica que una tarea tiene una categoria y una categoria tiene muchas tareas
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(150);
            tarea.Property(p => p.Descripcion).IsRequired().HasMaxLength(300);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(taskList);
        });



    }
}
