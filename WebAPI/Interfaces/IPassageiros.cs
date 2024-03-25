using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface IPassageiros
{
    public ICollection<Passageiro> Passageiros { get; set; }
}