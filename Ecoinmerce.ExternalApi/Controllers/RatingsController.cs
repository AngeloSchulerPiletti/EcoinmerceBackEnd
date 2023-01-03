using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Domain.Objects.VOs.Responses;
using Ecoinmerce.Infra.Ratings.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/ratings/")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IRatingsBusiness _ratingsBusiness;

    public RatingsController(IRatingsBusiness ratingsBusiness)
    {
        _ratingsBusiness = ratingsBusiness;
    }

    [HttpGet]
    [Route("quote/{fromCurrency}/{toCurrency}")]
    public IActionResult GetRatingQuote(string fromCurrency, string toCurrency)
    {
        MessageBagSingleEntityVO<RatingQuote> messageBagRating = _ratingsBusiness.GetRatingQuote(fromCurrency, toCurrency);
        return messageBagRating.IsError ? BadRequest(messageBagRating) : Ok(messageBagRating);
    }
}
