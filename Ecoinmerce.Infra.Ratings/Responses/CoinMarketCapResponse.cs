using Newtonsoft.Json;

namespace Ecoinmerce.Infra.Ratings.Responses;

public class CoinMarketCapResponse
{
    public Dictionary<int, CoinMarketCapResponseData> Data { get; set; }
    public CoinMarketCapResponseStatus Status { get; set; }
}
public class CoinMarketCapResponseData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    [JsonProperty("is_active")]
    public int IsActive { get; set; }
    [JsonProperty("is_fiat")]
    public int IsFiat { get; set; }
    [JsonProperty("circulating_supply")]
    public int CirculatingSupply { get; set; }
    [JsonProperty("total_supply")]
    public int TotalSupply { get; set; }
    [JsonProperty("max_supply")]
    public int MaxSupply { get; set; }
    [JsonProperty("date_added")]
    public DateTime DateAdded { get; set; }
    [JsonProperty("num_market_pairs")]
    public int NumMarketPairs { get; set; }
    [JsonProperty("cmc_rank")]
    public int CoinMarketCapRankPosition { get; set; }
    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }
    public Dictionary<string, CoinMarketCapResponseDataQuoting> Quote { get; set; }
}
public class CoinMarketCapResponseDataQuoting
{
    public decimal Price { get; set; }
    [JsonProperty("volume_24h")]
    public decimal VolumeLast24Hours { get; set; }
    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }
    //"volume_change_24h": -0.152774,
    //"percent_change_1h": 0.988615,
    //"percent_change_24h": 4.37185,
    //"percent_change_7d": -12.1352,
    //"percent_change_30d": -12.1352,
    //"market_cap": 852164659250.2758,
    //"market_cap_dominance": 51,
    //"fully_diluted_market_cap": 952835089431.14,
}
public class CoinMarketCapResponseStatus
{
    public DateTime Timestamp { get; set; }
    [JsonProperty("error_code")]
    public string ErrorCode { get; set; }
    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; }
    [JsonProperty("credit_count")]
    public int CreditCount { get; set; }
    //"elapsed": 10,
}
