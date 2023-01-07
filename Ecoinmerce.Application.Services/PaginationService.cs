using Ecoinmerce.Application.Services.Interfaces;
using Ecoinmerce.Domain.Objects.DTOs.Requests;
using Ecoinmerce.Domain.Objects.VOs.Responses;

namespace Ecoinmerce.Application.Services;

public class PaginationService : IPaginationService
{
    public MessageBagSingleEntityVO<PaginationDTO> MapPagination(int page, int limit)
    {
        if (limit > 100) return new MessageBagSingleEntityVO<PaginationDTO>("A paginação não pode ter mais de 100 items");
        
        return (page == 0 || limit == 0) ?
            new MessageBagSingleEntityVO<PaginationDTO>("A paginação não pode ter página 0 ou limite 0", "Erro ao mapear a paginação", true, null, "P001") :
            new MessageBagSingleEntityVO<PaginationDTO>("Mapeado com sucesso", null, false, new PaginationDTO(page, limit));
    }
}
