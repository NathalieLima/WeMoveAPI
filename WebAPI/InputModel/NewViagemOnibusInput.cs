
namespace WebAPI.InputModels;
public class NewViagemOnibusInput : INewViagemInput
{
    public required string Origem { get; set; }
    public required string Destino { get; set; }
    public required string Rota { get; set; }
    public required DateOnly Dia { get; set; }
    public required TimeOnly HoraSaida { get; set; }
    public required string CNHMotorista { get; set; }
     public required Guid OnibusId { get; set; }
}
