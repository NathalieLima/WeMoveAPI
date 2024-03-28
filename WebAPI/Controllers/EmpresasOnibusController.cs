using Microsoft.AspNetCore.Mvc;
using PersonsApi.Data;
using WebAPI.InputModels;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresasOnibusController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public EmpresasOnibusController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Post(NewEmpresaOnibusInput empresa) 
    {
        EmpresaOnibus novaEmpresa = new EmpresaOnibus {
            Id = new Guid(),
            Nome = empresa.Nome,
        };

        _dbContext.EmpresasOnibus.Add(novaEmpresa);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(Post), new { id = novaEmpresa.Id }, novaEmpresa);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var empresas = _dbContext.EmpresasOnibus.ToList();

        return Ok(empresas);
    }
}
