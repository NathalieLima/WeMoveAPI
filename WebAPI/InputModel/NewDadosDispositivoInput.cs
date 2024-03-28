namespace WebAPI.InputModels;
public class NewDadosDispositivoInput
{
    public required string DispositivoId { get; set; } 
    public int Latitude { get; set; } 
    public int Longitude { get; set; } 
    public int Velocidade { get; set; }
    public int Temperatura { get; set; }
    public string IrregularidadeSolo { get; set; }
    public string QualidadeAr { get; set; }
}
