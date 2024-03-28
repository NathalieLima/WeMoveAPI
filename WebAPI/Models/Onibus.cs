namespace WebAPI.Models;
public class Onibus : Veiculo
{
    // public Dispositivo Dispositivo { get; set; } //Presumindo que o dispositivo vai ser fixo e pré-determinado para cada ônibus
    public EmpresaOnibus EmpresaOnibus { get; set; }
    public int Linha { get; set; }
    public required bool TemArCondicionado { get; set; }
}
