using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class InstituicoesController : ControllerBase
{
    private static readonly List<Viagem> Summaries = new List<Viagem>();

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public InstituicoesController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost(Name = "CreateInstituicao")]
    public void Post(Instituicao instituicao) 
    {
        _dbContext.Instituicoes.Add(instituicao);
        _dbContext.SaveChanges();
    }

    [HttpGet(Name = "GetInstituicao")]
    public ICollection<Instituicao> Get()
    {
        return _dbContext.Instituicoes.ToList();
    }

    [HttpPatch(Name = "PatchInstituicao")]
    public IActionResult Patch()
    {
        return Ok();
    }
}
