

using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DadosDispositivoController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public DadosDispositivoController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(EmpresaOnibus empresa) 
    {
        EmpresaOnibus novaEmpresa = new EmpresaOnibus {
            // Id = new Guid(),
            Nome = empresa.Nome,
        };

        _dbContext.EmpresasOnibus.Add(novaEmpresa);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(Post), new { id = novaEmpresa.Id }, novaEmpresa);
    }

    [HttpGet("empresas")]
    public IActionResult Get()
    {
        var empresas = _dbContext.EmpresasOnibus.ToList();

        return Ok(empresas);
    }

    [HttpGet("empresas/{id}")]
    public IActionResult GetById([FromBody] Guid usuarioId)
    {
        var usuarios = _dbContext.ViagensCaronaOferta.ToList();
        var usuarioDB = usuarios.FirstOrDefault(usuario => usuario.Id != 1);

        return Ok(usuarioDB);
    }

    [HttpPut("empresa/{id}")]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete("empresa/{id}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}
