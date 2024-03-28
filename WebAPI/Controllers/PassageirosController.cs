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
        // var instituicaoDB = _dbContext.Instituicoes.FirstOrDefault(instituicao => instituicao.CNPJ == passageiro.InstituicaoCNPJ);

        if (usuarioDB != null)
        {
            var novoPassageiro = new Passageiro {
                ComprovanteInstituicao = passageiro.ComprovanteInstituicao,
                InstituicaoCNPJ = passageiro.InstituicaoCNPJ,
                Usuario = usuarioDB
            };

            _dbContext.Passageiros.Add(novoPassageiro);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Post), new { 
                comprovante = novoPassageiro.ComprovanteInstituicao, 
                instituicao = novoPassageiro.InstituicaoCNPJ 
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
    public IActionResult GetById(string comprovante, string instituicaoCNPJ)
    {
        var passageiro = _dbContext.Passageiros.ToList()
        .FirstOrDefault(passageiro => passageiro.ComprovanteInstituicao == comprovante && passageiro.InstituicaoCNPJ == instituicaoCNPJ);

        if (passageiro != null) {
            return Ok(passageiro);
        }

        return NotFound();
    }
}
