namespace WebAPI.Models;

public class Usuario
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; } //chave única
    public required string Apelido { get; set; }
}