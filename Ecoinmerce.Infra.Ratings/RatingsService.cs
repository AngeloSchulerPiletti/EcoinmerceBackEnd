using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.Ratings.Interfaces;
using Ecoinmerce.Infra.Ratings.Responses;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace Ecoinmerce.Infra.Ratings;

public class RatingsService : IRatingsService
{
    private readonly RatingsSettings _ratingsSettings;

    public RatingsService(RatingsSettings ratingsSettings)
    {
        _ratingsSettings = ratingsSettings;
    }

    public RatingQuote GetRating(RatingCode convertFrom, RatingCode convertTo)
    {
        return GetRatingFromCoinMarketCap(convertFrom, convertTo);
    }

    public RatingQuote GetRatingFromCoinMarketCap(RatingCode convertFrom, RatingCode convertTo)
    {
        NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["symbol"] = convertFrom.CoinMarketCapCode;
        queryString["convert"] = convertTo.CoinMarketCapCode;

        UriBuilder url = new(_ratingsSettings.CoinMarketCap.BaseUrl)
        {
            Path = "v2/cryptocurrency/quotes/latest",
            Query = queryString.ToString()
        };

        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _ratingsSettings.CoinMarketCap.AccessToken);

        HttpResponseMessage response = client.GetAsync(url.ToString()).Result;
        if (response == null || response.StatusCode != HttpStatusCode.OK) return null;

        CoinMarketCapResponse coinMarketCapResponse = response.Content.ReadFromJsonAsync<CoinMarketCapResponse>().Result;

        List<CoinMarketCapResponseData> quoteDataList = coinMarketCapResponse.Data[convertFrom.CoinMarketCapCode];
        if (coinMarketCapResponse.Status.ErrorCode != null || quoteDataList == null || quoteDataList.Count == 0) return null;

        RatingQuote ratingQuote = new()
        {
            CurrencyFrom = convertFrom.CoinMarketCapCode,
            CurrencyTo = convertTo.CoinMarketCapCode,
            Price = quoteDataList[0].Quote[convertTo.CoinMarketCapCode].Price,
            UpdatedAt = quoteDataList[0].Quote[convertTo.CoinMarketCapCode].LastUpdated,
        };
        return ratingQuote;
    }
}
