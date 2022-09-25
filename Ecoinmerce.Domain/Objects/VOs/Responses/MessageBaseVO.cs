namespace Ecoinmerce.Domain.Objects.VO.Responses
{
    public class MessageBaseVO
    {
        public MessageBaseVO( bool isError = true, string title = null)
        {
            Title = title;
            IsError = isError;
        }

        public string Title { get; set; }
        public bool IsError { get; }
    }
}
