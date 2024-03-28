using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PassageirosController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public PassageirosController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewPassageiroInput passageiro) 
    {
        var usuarioDB = _dbContext.Usuarios.FirstOrDefault(usuario => usuario.Email == passageiro.EmailUsuario);
        var instituicaoDB = _dbContext.Instituicoes.FirstOrDefault(instituicao => instituicao.Nome == passageiro.NomeInstituicao);

        if (usuarioDB != null && instituicaoDB != null)
        {
            var novoPassageiro = new Passageiro {
                ComprovanteInstituicao = passageiro.ComprovanteInstituicao,
                Instituicao = instituicaoDB,
                Usuario = usuarioDB
            };

            _dbContext.Passageiros.Add(novoPassageiro);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Post), new { 
                comprovante = novoPassageiro.ComprovanteInstituicao, 
                instituicao = novoPassageiro.Instituicao 
            }, novoPassageiro);
        }

        return NotFound();
    }

    [HttpGet]
    public ICollection<Passageiro> Get()
    {
        return _dbContext.Passageiros.ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string comprovante, string instituicao)
    {
        var passageiro = _dbContext.Passageiros.ToList()
        .FirstOrDefault(passageiro => passageiro.ComprovanteInstituicao == comprovante && passageiro.Instituicao.Nome == instituicao);

        if (passageiro != null) {
            return Ok(passageiro);
        }

        return NotFound();
    }
}
