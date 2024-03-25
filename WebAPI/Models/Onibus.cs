using WebAPI.Interfaces;

namespace WebAPI.Models;
public class Onibus : IVeiculo
{
    // public Dispositivo Dispositivo { get; set; } //Presumindo que o dispositivo vai ser fixo e pré-determinado para cada ônibus
    public EmpresaOnibus EmpresaOnibus { get; set; }
    public required bool TemArCondicionado { get; set; }
}
