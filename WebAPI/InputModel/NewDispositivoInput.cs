using WebAPI.Models;

namespace WebAPI.InputModels;
public class NewDispositivoInput
{
    public required string Id { get; set; }
    public required string PlacaOnibus { get; set; }
}
