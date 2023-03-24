




using System.Linq.Expressions;

namespace TemplateMicroservice.Domain.Extensions;

public static class IQueryableExtension
{
    public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int page, int limit)
    {
        return query.Skip((page - 1) * limit).Take(limit);
    }

    public static IQueryable<T> OrderByGeneric<T>(IQueryable<T> query, bool isOrderByDesc, string fieldNameOrderBy)
    {
        if (fieldNameOrderBy.Contains("."))
        {
            var parameter = Expression.Parameter(typeof(T), fieldNameOrderBy);

            // Cria uma expressão lambda para acessar a propriedade especificada
            Expression property = parameter;
            foreach (var prop in fieldNameOrderBy.Split('.'))
            {
                property = Expression.PropertyOrField(property, prop);
            }
            var lambda = Expression.Lambda(property, parameter);

            // Cria uma expressão para o método de ordenação a ser chamado
            var orderByMethod = isOrderByDesc ? "OrderByDescending" : "OrderBy";
            var orderByExpression = Expression.Call(
                typeof(Queryable),
                orderByMethod,
                new[] { typeof(T), property.Type },
                query.Expression,
                lambda
            );

            return query.Provider.CreateQuery<T>(orderByExpression);
        }
        else
        {

            var parameter = Expression.Parameter(typeof(T), fieldNameOrderBy);
            var property = Expression.Property(parameter, fieldNameOrderBy);
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

            if (isOrderByDesc)
            {
                return query.OrderByDescending(lambda);
            }
            else
            {
                return query.OrderBy(lambda);
            }

        }
    }

}



