namespace WebAPI.Models;
public class Dispositivo
{
    public required string Id { get; set; } 
    // public required string NomeFornecedora { get; set; } //aqui ser uma instituicao? 
    public Onibus Onibus { get; set; }
}
