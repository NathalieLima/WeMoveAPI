namespace WebAPI.Models;
public class DadosDispositivo
{
    // data já vou pegar a do ônibus e hora é o timestamp
    
    public Guid Id { get; set; } 
    public Dispositivo IdDispositivo { get; set; } 
    public Onibus Onibus { get; set; }
    
    public int Latitude { get; set; } 
    public int Longitude { get; set; } 
    // public int Velocidade { get; set; }
    // public int Temperatura { get; set; }
    // public string IrregularidadeSolo { get; set; }
    // public string QualidadeAr { get; set; }

}
