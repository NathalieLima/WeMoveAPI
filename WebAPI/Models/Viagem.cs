using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace WebAPI.Models;

public class Viagem
{
    public int Id { get; set; } = default!;
    public string Origem { get; set; } = default!;
    public required string Destino { get; set; }
    public required string Rota { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public required DateTime Dia { get; set; }

    public required string HoraSaida { get; set; }
    public Motorista Motorista { get; set; }

}