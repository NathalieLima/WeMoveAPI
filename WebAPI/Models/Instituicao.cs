namespace WebAPI.Models;
public class Instituicao
{
    public required string CNPJ { get; set; }
    public required string Nome { get; set; }
    public required string Endereco { get; set; }
    public required string Tipo { get; set; }
    public required string Telefone { get; set; }
}
