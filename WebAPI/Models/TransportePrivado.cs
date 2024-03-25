using WebAPI.Interfaces;

namespace WebAPI.Models;

public class TransportePrivados : IVeiculo, IPassageiros
{
    public Usuario Dono { get; set; }
    public ICollection<Passageiro>? Passageiros { get; set; }
}