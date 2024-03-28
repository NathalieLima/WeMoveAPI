using WebAPI.Interfaces;

namespace WebAPI.Models;
public class VeiculoCarona : Veiculo, ITipoVeiculo
{
    public string Tipo { get; set; }
}
