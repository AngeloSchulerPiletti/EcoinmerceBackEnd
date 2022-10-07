using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Services.Interfaces;

public interface IPaginationService
{
    public MessageBagSingleEntityVO<PaginationDTO> MapPagination(int page, int limit);
}
