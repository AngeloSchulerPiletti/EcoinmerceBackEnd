namespace BarterHash.Domain.Objects.VO.Responses
{
    public class MessageBagVO : MessageBaseVO
    {
        public MessageBagVO(string message,
                            int reference,
                            bool isError = true,
                            string title = null
                            ) : base(reference, isError, title)
        {
            Messages = new List<string>() { message };
        }

        public List<string> Messages { get; }
    }

    public class MessageBagVO<TEntity> : MessageBagVO where TEntity : class
    {
        public MessageBagVO(string message,
                            int reference,
                            bool isError = true,
                            string title = null,
                            TEntity entity = null
                            ) : base(message, reference, isError, title)
        {
            Entities = entity != null ? new List<TEntity>() { entity } : new List<TEntity>();
        }

        public List<TEntity> Entities { get; set; }
    }
}
