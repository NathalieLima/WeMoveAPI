namespace WebAPI.InputModels;
public interface INewViagemInput
{
    public string Origem { get; set; }
    public string Destino { get; set; }
    public string Rota { get; set; } //ser array
    public DateOnly Dia { get; set; }

    public TimeOnly HoraSaida { get; set; }
    public string CNHMotorista { get; set; }
}
