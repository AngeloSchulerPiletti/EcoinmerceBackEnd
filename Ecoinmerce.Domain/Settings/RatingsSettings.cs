namespace Ecoinmerce.Domain.Settings;

public class RatingsSettings
{
    public RatingsApiSettings CoinMarketCap { get; set; }
    public RatingsApiSettings Coinbase { get; set; }
    public RatingsApiSettings Etherscan { get; set; }
}

public class RatingsApiSettings
{
    public string AccessToken { get; set; }
    public string BaseUrl { get; set; }
}

public class RatingCode
{
    public string CoinMarketCapCode;

    public RatingCode(string coinMarketCapCode)
    {
        CoinMarketCapCode = coinMarketCapCode;
    }
}


public static class RatingsCodes
{
    public static RatingCode Ether = new ("ETH");
    public static RatingCode Bitcoin = new ("BTC");
    public static RatingCode BrazilianReal = new ("BRL");
}
