namespace WebAPI.Models;
// mesmo veiculo pra + de um motorista?
public class Veiculo
{
    public Guid Id { get; set; }
    public required string Placa { get; set; }
    public required int Capacidade { get; set; } //carro pode ter capacidade de 2/5
}
