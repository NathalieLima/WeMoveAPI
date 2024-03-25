using WebAPI.Interfaces;

namespace WebAPI.Models;

public class ViagemCaronaOferta : Viagem, INumeroVagas, IPassageiros
{
    public int NumeroVagas { get; set; }
    public ICollection<Passageiro>? Passageiros { get; set; }
}