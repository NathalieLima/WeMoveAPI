using WebAPI.Models;

namespace WebAPI.InputModels;
public class NewOnibusInput 
{
    public required string Placa { get; set; }
    public required string Tipo { get; set; }
    public required string Capacidade { get; set; }
    public required string EmpresaOnibusNome { get; set; }
    public required bool TemArCondicionado { get; set; }
}
