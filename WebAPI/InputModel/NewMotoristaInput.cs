using WebAPI.Models;

namespace WebAPI.InputModels;
public class NewMotoristaInput 
{
    public required string CNH { get; set; }
    public required string EmailUsuario { get; set; }
}
