using WebAPI.Models;

namespace WebAPI.InputModels;
public class NewDispositivoInput
{
    public Guid Id { get; set; } 
    public required string NomeFornecedora { get; set; }
    public Onibus Onibus { get; set; }
}
