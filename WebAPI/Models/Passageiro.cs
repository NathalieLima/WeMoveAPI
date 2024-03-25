namespace WebAPI.Models;

public class Passageiro 
{
    public Guid Id { get; set; }
    public Usuario Usuario { get; set; }
    public string ComprovanteInstituicao { get; set; }
    public Instituicao IdInstituicao { get; set; }
    
}