namespace Ecoinmerce.Domain.Objects.DTOs.Requests
{
    public class PaginationDTO
    {
        public PaginationDTO(int page = 1, int limit = 10)
        {
            Page = page;
            Limit = limit;
            Skip = limit * (page - 1);
        }

        public int Page { get; set; }
        public int Limit { get; set; }
        public int Skip { get; set; }
        public int? LastPage { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int? TotalItems { get; set; }

        public void FillBasedInTotalItems(int totalItems)
        {
            TotalItems = totalItems;
            LastPage = (int?)Math.Ceiling(Decimal.Divide(totalItems, Limit));
            NextPage = (Page * Limit < totalItems) ? (Page + 1 <= LastPage ? Page + 1 : null) : null;
            PreviousPage = Page > 1 ? (Page - 1 < LastPage ? Page - 1 : null) : null;
        }
    }
}
