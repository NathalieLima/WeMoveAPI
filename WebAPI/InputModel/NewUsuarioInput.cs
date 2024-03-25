namespace WebAPI.InputModels;

public class NewUsuarioInput
{
    public required  string Nome { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public required string Apelido { get; set; }
}