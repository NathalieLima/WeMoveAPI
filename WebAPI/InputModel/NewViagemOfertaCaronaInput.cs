
namespace WebAPI.InputModels;
public class NewViagemOfertaCaronaInput : INewViagemInput
{
    public required string Origem { get; set; }
    public required string Destino { get; set; }
    public required string Rota { get; set; }
    public required DateOnly Dia { get; set; }
    public required TimeOnly HoraSaida { get; set; }
    public int NumeroVagas { get; set; }
    public required string CNHMotorista { get; set; }
}
