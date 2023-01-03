using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.Ratings.Responses;

namespace Ecoinmerce.Application.Interfaces;

public interface IRatingsBusiness
{
    public MessageBagSingleEntityVO<RatingQuote> GetRatingQuote(string convertFrom, string convertTo);
}
