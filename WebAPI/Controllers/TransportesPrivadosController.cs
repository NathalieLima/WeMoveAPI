using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TransportePrivadosController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public TransportePrivadosController(ApplicationDbContext dbContext)
    {
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
