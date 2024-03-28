using WebAPI.Interfaces;

namespace WebAPI.Models;

public class TransportePrivados : Veiculo, IPassageiros
{
    public Usuario Dono { get; set; }
    public ICollection<Passageiro>? Passageiros { get; set; }
}