using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class dataBaseController : ControllerBase
{
    TareasContext dbContext;
    public dataBaseController(TareasContext db)
    {
        dbContext = db;
    }

    [HttpGet]
    public IActionResult createDataBase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}