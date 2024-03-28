using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public UsuariosController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewUsuarioInput usuario) 
    {
        Usuario novoUsuario = new Usuario {
            Nome = usuario.Nome,
            Apelido = usuario.Apelido,
            Email = usuario.Email,
            Telefone = usuario.Telefone,
            Id = new Guid()
        };

        _dbContext.Usuarios.Add(novoUsuario);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(Post), new { id = novoUsuario.Id }, novoUsuario);
    }

    [HttpGet]
    public ICollection<Usuario> Get()
    {
        return _dbContext.Usuarios.ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromBody] Guid usuarioId)
    {
        var usuarioDB = _dbContext.Usuarios.FirstOrDefault(usuario => usuario.Id == usuarioId);

        return Ok(usuarioDB);
    }
}
