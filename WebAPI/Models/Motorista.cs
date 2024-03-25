using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Motorista 
{
    [Key]
    public string CNH { get; set; }
    public Usuario Usuario { get; set; }
}