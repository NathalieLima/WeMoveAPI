using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MotoristasController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public MotoristasController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost]
    public void Post(NewMotoristaInput motorista) 
    {
        Motorista novoMotorista = new Motorista();
        var usuarioDB = _dbContext.Usuarios.FirstOrDefault(usuario => usuario.Email == motorista.EmailUsuario);

        if (usuarioDB != null)
        {
            novoMotorista.Usuario = usuarioDB;
            novoMotorista.CNH = motorista.CNH;

            _dbContext.Motoristas.Add(novoMotorista);
            _dbContext.SaveChanges();
        }        
    }

    [HttpGet]
    public ICollection<Motorista> Get()
    {
        return _dbContext.Motoristas.ToList();
    }

    [HttpGet("{id}")]
    public ICollection<Motorista> GetById()
    {
        return _dbContext.Motoristas.ToList();
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
