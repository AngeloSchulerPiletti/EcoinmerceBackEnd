namespace Ecoinmerce.Domain.Objects.VO.Responses
{
    public class MessageBagVO : MessageBaseVO
    {
        public MessageBagVO(string message = null,
                            string title = null,
                            bool isError = true
                            ) : base(isError, title)
        {
            Messages = message == null ? new List<string>() : new List<string>() { message };
        }

        public List<string> Messages { get; }
    }
}
