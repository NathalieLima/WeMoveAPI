using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PassageirosController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public PassageirosController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost]
    public void Post(ViagemCaronaOferta viagem) 
    {
        _dbContext.ViagensCaronaOferta.Add(viagem);
        _dbContext.SaveChanges();
    }

    [HttpGet]
    public ICollection<ViagemCaronaOferta> Get()
    {
        return _dbContext.ViagensCaronaOferta.ToList();
    }

    [HttpGet("{id}")]
    public ICollection<ViagemCaronaOferta> GetById()
    {
        return _dbContext.ViagensCaronaOferta.ToList();
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
