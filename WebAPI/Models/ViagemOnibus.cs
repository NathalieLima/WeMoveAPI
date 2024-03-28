using WebAPI.Interfaces;

namespace WebAPI.Models;

public class ViagemOnibus : Viagem
{
    public Onibus Onibus { get; set; }
}