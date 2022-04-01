namespace BarterHash.Domain.Objects.VO.Responses
{
    public class MessageBaseVO
    {
        public MessageBaseVO(int reference, bool isError = true, string title = null)
        {
            Reference = reference;
            Title = title;
            IsError = isError;
        }

        public int Reference { get; }
        public string Title { get; set; }
        public bool IsError { get; }
    }
}
