namespace Ecoinmerce.Domain.Objects.VOs.Responses;

public class ViaCepResponseVO
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string Ibge { get; set; }
    public string Uf { get; set; }
    public string Ddd { get; set; }
    public string Erro { get; set; }
}
