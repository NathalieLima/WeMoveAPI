using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class Passageiro 
{
    public Usuario Usuario { get; set; }
    public string ComprovanteInstituicao { get; set; }
    public required string InstituicaoCNPJ { get; set; }   
}