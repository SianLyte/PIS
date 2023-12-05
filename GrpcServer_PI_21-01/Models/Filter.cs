using System.Linq.Expressions;
using System.Reflection;

namespace GrpcServer_PI_21_01.Models
{
    public class Filter<T>
    {
        public Filter()
        {
            var type = typeof(T);
            var filterableModelAttribute = type.GetCustomAttributes<FilterableModelAttribute>()
                .SingleOrDefault();
            if (filterableModelAttribute is null)
                throw new Exception("This model cannot be filtered.");

            equations = new List<string>();
            tableName = filterableModelAttribute.TableName;
        }

        public Filter(FilterReply reply) : this()
        {
            if (reply is not null)
            {
                equations.AddRange(reply.Equations);
                if (!CheckCorrectFormat()) // проверка на попытки нежелаемых SQL инжектов
                    throw new Exception("Incorrect reply format recieved. Filter reply is corrupted");
            }
        }

        public IReadOnlyList<string> CurrentFilters => equations;

        /// <summary>
        /// Adds a filter.
        /// <example>
        /// <code>
        /// <para/>// quick example for Act class:
        /// <para/>filter.AddFilter(act => act.DogCount, "2", FilterType.Equals | FilterType.GreaterThan)
        /// </code>
        /// </example> 
        /// </summary>
        /// <typeparam name="TValue">Property Type</typeparam>
        /// <param name="selector">Property with [Filterable] attribute <br/> Example : <code>act => act.Organization</code></param>
        /// <param name="desiredValue">Desired value of this property <br/> Example : <code>"1"</code>
        /// <br/> will mean that target value for SQL query and operator will be "1".
        /// If <paramref name="selector"/> is chosen for Organizations, this will mean organizations with id 1.</param>
        /// <param name="filterType"> Which operator to use in SQL query for comparison,
        /// <br/> Example : <code>FilterType.Equals | FilterType.GreaterThan</code> <br/> will return SQL query with operator '>='</param>
        /// <exception cref="InvalidFilterCriteriaException">Will be thrown
        /// if <paramref name="selector"/>'s property does not have [Filterable] attribute
        /// </exception>
        public void AddFilter<TValue>(Expression<Func<T, TValue>> selector,
            string desiredValue, FilterType filterType = FilterType.Equals)
        {
            var property = Filter<T>.GetProperty(selector);
            var filterable = property.GetCustomAttributes<FilterableAttribute>().SingleOrDefault();
            if (filterable is null)
                throw new InvalidFilterCriteriaException("Cannot filter property " + property.Name);

            var @operator = string.Empty;
            if (filterType.HasFlag(FilterType.GreaterThan))
                @operator += ">";
            else if (filterType.HasFlag(FilterType.LesserThan))
                @operator += "<";
            if (filterType.HasFlag(FilterType.Equals))
                @operator += "=";

            var equation = $"{filterable.ColumnName} {@operator} {desiredValue}";
            equations.Add(equation);
        }

        public void RemoveFilterAt(int index)
        {
            equations.RemoveAt(index);
        }

        private static PropertyInfo GetProperty<TValue>(Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression expression)
                body = expression.Body;
            return body.NodeType switch
            {
                ExpressionType.MemberAccess => (PropertyInfo)((MemberExpression)body).Member,
                _ => throw new InvalidOperationException(),
            };
        }

        public string GenerateSQL()
        {
            var startQuery = $"SELECT * FROM {tableName}";
            if (equations.Count > 0)
                startQuery += $" WHERE {string.Join(" and ", equations)};";
            else startQuery += ";";
            
            return startQuery;
        }

        private bool CheckCorrectFormat()
        {
            return equations.All(eq =>
            {
                var items = eq.Split(' ');
                return items.Length == 3 && items[1].Length <= 2
                    && (items[1].Length == 1 || items[1][1] == '=');
            });
        }

        public void CombineWith(Filter<T> filter)
        {
            if (filter is null) return;
            equations.AddRange(filter.equations);
        }

        private readonly List<string> equations;
        private readonly string tableName;
    }

    public enum FilterType
    {
        Equals,
        GreaterThan,
        LesserThan,
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FilterableAttribute : Attribute
    {
        public FilterableAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public string ColumnName { get; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class FilterableModelAttribute : Attribute
    {
        public FilterableModelAttribute(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; }
    }
}
