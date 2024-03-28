namespace WebAPI.Models;
public class DadosDispositivo
{
    // data já vou pegar a do ônibus e hora é o timestamp
    
    public Guid Id { get; set; } 
    public Dispositivo Dispositivo { get; set; } 
    public required int Latitude { get; set; } 
    public required int Longitude { get; set; } 
    public int Velocidade { get; set; }
    public int Temperatura { get; set; }
    public string IrregularidadeSolo { get; set; } = default!;
    public string QualidadeAr { get; set; } = default!;
}
