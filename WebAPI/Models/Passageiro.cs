namespace WebAPI.Models;

public class Passageiro 
{
    public Usuario Usuario { get; set; }
    public string ComprovanteInstituicao { get; set; }
    public Instituicao Instituicao { get; set; }   
}