using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class InstituicoesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public InstituicoesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost(Name = "CreateInstituicao")]
    public IActionResult Post(NewInstituicaoInput instituicao) 
    {
        var novaInstituicao = new Instituicao {
            Nome = instituicao.Nome,
            CNPJ = instituicao.CNPJ,
            Endereco = instituicao.Endereco,
            Tipo = instituicao.Tipo,
            Telefone = instituicao.Telefone
        };

        _dbContext.Instituicoes.Add(novaInstituicao);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(Post), new { id = novaInstituicao.CNPJ }, novaInstituicao);
    }

    [HttpGet(Name = "GetInstituicao")]
    public ICollection<Instituicao> Get()
    {
        return _dbContext.Instituicoes.ToList();
    }
}
