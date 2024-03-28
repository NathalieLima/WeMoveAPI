using WebAPI.Models;

namespace WebAPI.InputModels;
public class NewPassageiroInput 
{
    public required string EmailUsuario { get; set; }
    public required string ComprovanteInstituicao { get; set; }
    public required string NomeInstituicao { get; set; } //mudar para id depois
}
