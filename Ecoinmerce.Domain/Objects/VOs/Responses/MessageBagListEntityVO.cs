namespace Ecoinmerce.Domain.Objects.VO.Responses
{
    public class MessageBagListEntityVO<TEntity> : MessageBagVO where TEntity : class
    {
        public MessageBagListEntityVO(string message = null,
                            string title = null,
                            bool isError = true,
                            TEntity entity = null
                            ) : base(message, title, isError)
        {
            Entities = entity != null ? new List<TEntity>() { entity } : new List<TEntity>();
        }

        public List<TEntity> Entities { get; set; }
    }


}
