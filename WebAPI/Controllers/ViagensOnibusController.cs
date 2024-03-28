using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ViagensOnibusController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ViagensOnibusController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewViagemOnibusInput viagem) 
    {
        var motoristaDB = _dbContext.Motoristas.FirstOrDefault(motorista => motorista.CNH == viagem.CNHMotorista);
        var onibusDB = _dbContext.Onibus.FirstOrDefault(onibus => onibus.Id == viagem.OnibusId);

        if (motoristaDB != null && onibusDB != null) 
        {
            var novaViagem = new ViagemOnibus {
                Id = Guid.NewGuid(),
                Destino = viagem.Destino,
                Origem = viagem.Origem,
                Dia = viagem.Dia,
                HoraSaida = viagem.HoraSaida,
                Rota = viagem.Rota,
                Motorista = motoristaDB,
                Onibus = onibusDB

            };

            _dbContext.ViagensOnibus.Add(novaViagem);
            _dbContext.SaveChanges();
            
            return CreatedAtAction(nameof(Post), new { id = novaViagem.Id }, novaViagem);
        }

        return NotFound();
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
}
