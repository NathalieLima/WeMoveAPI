using WebAPI.Models;

namespace WebAPI.InputModels;
public class NewOnibusInput 
{
    public required string Placa { get; set; }
    public required int Capacidade { get; set; }
    public required string EmpresaOnibusCNPJ { get; set; }
    public int Linha { get; set; }
    public required bool TemArCondicionado { get; set; }
}
