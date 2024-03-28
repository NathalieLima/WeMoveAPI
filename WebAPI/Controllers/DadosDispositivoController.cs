

using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DadosDispositivoController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public DadosDispositivoController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewDadosDispositivoInput dados) 
    {
        var dispositivoDB = _dbContext.Dispositivos.FirstOrDefault(dispositivo => dispositivo.Id == dados.DispositivoId);

        if (dispositivoDB != null) 
        {
            var novoDado = new DadosDispositivo {
                Id = Guid.NewGuid(),
                Dispositivo = dispositivoDB,
                Latitude = dados.Latitude,
                Longitude = dados.Longitude,
                IrregularidadeSolo = dados.IrregularidadeSolo,
                QualidadeAr = dados.QualidadeAr,
                Temperatura = dados.Temperatura,
                Velocidade = dados.Velocidade
            };

            _dbContext.DadosDispositivos.Add(novoDado);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = novoDado.Id }, novoDado);
        }
        
        return NotFound();
    }

    [HttpGet]
    public IActionResult Get()
    {
        var empresas = _dbContext.EmpresasOnibus.ToList();

        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromBody] Guid idDispositivo)
    {
        var usuarioDB = _dbContext.ViagensCaronaOferta.FirstOrDefault(dispositivo => dispositivo.Id == idDispositivo);

        return Ok(usuarioDB);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}
