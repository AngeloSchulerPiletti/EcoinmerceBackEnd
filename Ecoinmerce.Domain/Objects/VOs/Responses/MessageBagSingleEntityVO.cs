namespace Ecoinmerce.Domain.Objects.VO.Responses
{
    public class MessageBagSingleEntityVO<TEntity> : MessageBagVO where TEntity : class
    {
        public MessageBagSingleEntityVO(string message = null,
                            string title = null,
                            bool isError = true,
                            TEntity entity = null
                            ) : base(message, title, isError)
        {
            Entity = entity;
        }

        public TEntity Entity { get; set; }
    }
}
