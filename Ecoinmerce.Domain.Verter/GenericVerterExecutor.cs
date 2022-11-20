using Ecoinmerce.Domain.Objects.VOs.Responses;
using System.Reflection;

namespace Ecoinmerce.Domain.Verter;

public static class GenericVerterExecutor
{
    public static MessageBagSingleEntityVO<TEntity> UpdateEntityFromObject<TEntity, TObject>(TObject objectEntity, TEntity entity, List<string> ignoredProperties = null) where TEntity : class where TObject : class
    {
        ignoredProperties ??= new List<string>();
        PropertyInfo[] propertyInfos = typeof(TObject).GetProperties();
        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            string propertyName = propertyInfo.Name;

            if (!ignoredProperties.Contains(propertyName))
            {
                PropertyInfo customerProperty = typeof(TEntity).GetProperty(propertyName);
                if (customerProperty != null)
                {
                    object value = propertyInfo.GetValue(objectEntity);
                    if (value != null)
                    {
                        customerProperty.SetValue(entity, value);
                    }
                }
            }
        }
        return new MessageBagSingleEntityVO<TEntity>("Campos mapeados", "Sucesso", false, entity);
    }
}
