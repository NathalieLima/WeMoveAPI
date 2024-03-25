namespace WebAPI.Models;
public class Dispositivo
{
    public Guid Id { get; set; } 
    public required string NomeFornecedora { get; set; }
    public Onibus Onibus { get; set; }
}
