namespace WebAPI.Models;

public class Viagem
{
    public Guid Id { get; set; } = default!;
    public string Origem { get; set; } = default!;
    public required string Destino { get; set; }
    public required string Rota { get; set; } //ser array
    public required DateOnly Dia { get; set; }

    public required TimeOnly HoraSaida { get; set; }
    public Motorista Motorista { get; set; }
}

// alguma forma de ativar a viagem