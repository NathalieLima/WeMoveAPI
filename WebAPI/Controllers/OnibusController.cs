using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OnibusController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public OnibusController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewOnibusInput onibus) 
    {
        var empresaOnibusDB = _dbContext.EmpresasOnibus.FirstOrDefault(empresa => empresa.Nome == onibus.EmpresaOnibusNome);

        if (empresaOnibusDB != null) 
        {
            var novoOnibus = new Onibus {
                Capacidade = onibus.Capacidade,
                EmpresaOnibus = empresaOnibusDB,
                Placa = onibus.Placa,
                TemArCondicionado = onibus.TemArCondicionado,
                Tipo = onibus.Tipo

            };

            _dbContext.Onibus.Add(novoOnibus);
            _dbContext.SaveChanges();

            return Ok(novoOnibus);
        }

        return StatusCode(401, "Empresa não encontrada");
    }

    [HttpGet]
    public ICollection<Onibus> Get()
    {
        return _dbContext.Onibus.ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var onibusDB = _dbContext.Onibus.FirstOrDefault(onibus => onibus.Id == id);

        return Ok(onibusDB);
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
