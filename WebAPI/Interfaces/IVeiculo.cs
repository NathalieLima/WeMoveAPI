namespace WebAPI.Interfaces;
// mesmo veiculo pra + de um motorista?
public class IVeiculo
{
    public Guid Id { get; set; }
    public required string Placa { get; set; }
    public required string Tipo { get; set; }
    public required string Capacidade { get; set; }
    
}
