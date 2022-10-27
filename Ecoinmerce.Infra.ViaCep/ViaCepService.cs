using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.ViaCep.Interfaces;
using System.Text.Json;

namespace Ecoinmerce.Infra.ViaCep;

public static class ViaCepService
{
    private const string _baseUrl = "https://viacep.com.br";

    public static ViaCepResponseVO GetCompleteAddress(string cep)
    {
        string completeUrl = $"{_baseUrl}/ws/{cep}/json/";

        HttpClient client = new();
        HttpRequestMessage request = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(completeUrl)
        };

        HttpResponseMessage response = client.Send(request);
        if (!response.IsSuccessStatusCode) return null;

        string jsonResponse = response.Content.ReadAsStringAsync().Result;
        ViaCepResponseVO viaCepResponse = JsonSerializer.Deserialize<ViaCepResponseVO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return viaCepResponse.Erro == "true" ?
            null :
            viaCepResponse;
    }
}
