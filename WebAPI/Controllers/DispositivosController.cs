using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DispositivosController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public DispositivosController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewDispositivoInput dispositivo) //frombody?
    {
        var onibusDB = _dbContext.Onibus.FirstOrDefault(onibus => onibus.Placa == dispositivo.PlacaOnibus);

        if (onibusDB != null)
        {
            var novoDispositivo = new Dispositivo {
                Id = dispositivo.Id,
                Onibus = onibusDB,
            };

            _dbContext.Dispositivos.Add(novoDispositivo);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = novoDispositivo.Id }, novoDispositivo);
        }

        return NotFound();
    }

    [HttpGet]
    public ICollection<Dispositivo> Get()
    {
        return _dbContext.Dispositivos.ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var dispositivo = _dbContext.Dispositivos.ToList().FirstOrDefault(dispositivo => dispositivo.Id == id);

        if (dispositivo != null) {
            return Ok(dispositivo);
        }

        return NotFound();
    }
}
