using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.Ratings.Interfaces;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace Ecoinmerce.Infra.Ratings;

public class RatingsService : IRatingsService
{
    private readonly RatingsSettings _ratingsSettings;

    public RatingsService(RatingsSettings ratingsSettings)
    {
        _ratingsSettings = ratingsSettings;
    }

    public decimal? GetRatingFromCoinMarketCap(RatingCode convertFrom, RatingCode convertTo)
    {
        NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["symbol"] = convertFrom.CoinMarketCapCode;
        queryString["convert"] = convertTo.CoinMarketCapCode;

        UriBuilder url = new(_ratingsSettings.CoinMarketCap.BaseUrl)
        {
            Path = "v2/cryptocurrency/listings/latest",
            Query = queryString.ToString()
        };

        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _ratingsSettings.CoinMarketCap.AccessToken);

        HttpResponseMessage response = client.GetAsync(url.ToString()).Result;
        if(response == null || response.StatusCode != HttpStatusCode.OK) {
            return null;
        }
        response.Content.
    }
}
