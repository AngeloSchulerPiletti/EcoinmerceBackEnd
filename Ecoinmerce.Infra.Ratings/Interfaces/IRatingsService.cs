using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.Ratings.Responses;

namespace Ecoinmerce.Infra.Ratings.Interfaces;

public interface IRatingsService
{
    public RatingQuote GetRatingFromCoinMarketCap(RatingCode convertFrom, RatingCode convertTo);
}
