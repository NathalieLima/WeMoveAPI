using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class EmpresaOnibus
{
    [Key]
    public required string CNPJ { get; set; }
    public required string Nome { get; set; }
    
    // public ICollection<Onibus>? Onibus { get; set; } 
}
