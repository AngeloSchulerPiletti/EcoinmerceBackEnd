using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.Ratings.Interfaces;
using Ecoinmerce.Infra.Ratings.Responses;

namespace Ecoinmerce.Application;

public class RatingsBusiness : IRatingsBusiness
{
    private readonly IRatingsService _ratingsService;

    public RatingsBusiness(IRatingsService ratingsService)
    {
        _ratingsService = ratingsService;
    }

    public MessageBagSingleEntityVO<RatingQuote> GetRatingQuote(string convertFrom, string convertTo)
    {
        RatingCode fromRatingCode = new(convertFrom);
        RatingCode toRatingCode = new(convertTo);

        RatingQuote ratingQuote = _ratingsService.GetRating(toRatingCode, fromRatingCode);
        return ratingQuote == null ?
            new MessageBagSingleEntityVO<RatingQuote>("Erro no provedor de cotação", "Não foi possível converter a moeda", true) :
            new MessageBagSingleEntityVO<RatingQuote>("Conversão realizada com sucesso", null, false, ratingQuote);
    }
}
