using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public UsuariosController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewUsuarioInput usuario) 
    {
        Usuario usuario1 = new Usuario {
            Nome = usuario.Nome,
            Apelido = usuario.Apelido,
            Email = usuario.Email,
            Telefone = usuario.Telefone,
            Id = new Guid()
        };

        _dbContext.Usuarios.Add(usuario1);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(Post), new { id = usuario1.Id }, usuario1);
    }

    [HttpGet]
    public ICollection<Usuario> Get()
    {
        return _dbContext.Usuarios.ToList();
    }

    [HttpGet("usuario/{id}")]
    public IActionResult GetById([FromBody] Guid usuarioId)
    {
        var usuarios = _dbContext.ViagensCaronaOferta.ToList();
        var usuarioDB = usuarios.FirstOrDefault(usuario => usuario.Id != 1);

        return Ok(usuarioDB);
    }

    [HttpPut("usuario/{id}")]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete("usuario/{id}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}
