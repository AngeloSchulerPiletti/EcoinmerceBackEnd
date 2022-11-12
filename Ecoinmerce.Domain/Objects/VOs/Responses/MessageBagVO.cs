namespace Ecoinmerce.Domain.Objects.VOs.Responses;

public class MessageBagVO : IMessageBaseVO
{
    public MessageBagVO(string message = null,
                        string title = null,
                        bool isError = true,
                        string errorCode = null)
    {
        Title = title;
        IsError = isError;
        ErrorCode = errorCode;
        Messages = message == null ? new List<string>() : new List<string>() { message };
    }

    public string Title { get; set; }
    public bool IsError { get; set; }
    public List<string> Messages { get; }
    public Dictionary<string, object> DictionaryMessages { get; set; } = new();
    public string ErrorCode { get; set; }

    public static MessageBagVO MapMessageBagVOFromMessageBagSingleEntityVO<TEntity>(MessageBagSingleEntityVO<TEntity> messageBagSingleEntityVO) where TEntity : class
    {
        MessageBagVO messageBag = new()
        {
            Title = messageBagSingleEntityVO.Title,
            IsError = messageBagSingleEntityVO.IsError,
            ErrorCode = messageBagSingleEntityVO.ErrorCode
        };
        messageBag.Messages.AddRange(messageBagSingleEntityVO.Messages);
        return messageBag;
    }
}
