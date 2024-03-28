using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OnibusController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public OnibusController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewOnibusInput onibus) 
    {
        var empresaOnibusDB = _dbContext.EmpresasOnibus.FirstOrDefault(empresa => empresa.CNPJ == onibus.EmpresaOnibusCNPJ);

        if (empresaOnibusDB != null) 
        {
            var novoOnibus = new Onibus {
                Capacidade = onibus.Capacidade,
                EmpresaOnibus = empresaOnibusDB,
                Placa = onibus.Placa,
                TemArCondicionado = onibus.TemArCondicionado,
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
}
