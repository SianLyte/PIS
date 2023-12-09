using System.Linq.Expressions;
using System.Reflection;

namespace GrpcClient_PI_21_01.Models
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

            andEquations = new List<string>();
            orEquations = new List<string>();
            innerEquations = new List<string>();
        }

        public IReadOnlyList<string> AndFilters => andEquations;
        public IReadOnlyList<string> OrFilters => orEquations;
        public IReadOnlyList<string> InnerJoinFilters => innerEquations;

        /// <summary>
        /// Adds an 'and' filter.
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
            var equation = GenerateEquation(selector, desiredValue, filterType);
            andEquations.Add(equation);
        }

        /// <summary>
        /// Adds an 'or' filter.<br/>Usage is the same as for
        /// <see cref="AddFilter{TValue}(Expression{Func{T, TValue}}, string, FilterType)"/>.
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
        public void AddOrFilter<TValue>(Expression<Func<T, TValue>> selector,
            string desiredValue, FilterType filterType = FilterType.Equals)
        {
            var equation = GenerateEquation(selector, desiredValue, filterType);
            orEquations.Add(equation);
        }

        
        public void AddInnerJoinFilter<ObjectType, TValue>(Expression<Func<ObjectType, TValue>> selector,
            string desiredValue, FilterType filterType = FilterType.Equals)
        {
            var column = GetColumnID(selector);
            var @operator = GetOperator(filterType);

            if (typeof(TValue) != typeof(decimal) && typeof(TValue) != typeof(double)
                && typeof(TValue) != typeof(int) && typeof(TValue) != typeof(float)) desiredValue = $"'{desiredValue}'";

            var equation = $"{typeof(ObjectType).Name}.{column} {@operator} {desiredValue}";
            innerEquations.Add(equation);
        }

        private static string GetColumnID<ObjectType, TValue>(Expression<Func<ObjectType, TValue>> selector)
        {
            var property = Filter<T>.GetProperty(selector);
            var filterable = property.GetCustomAttributes<FilterableAttribute>().SingleOrDefault();
            if (filterable is null)
                throw new InvalidFilterCriteriaException("Cannot filter property " + property.Name);

            return filterable.ColumnName;
        }

        private static string GetOperator(FilterType filterType)
        {
            var @operator = string.Empty;
            if (filterType.HasFlag(FilterType.GreaterThan))
                @operator += ">";
            else if (filterType.HasFlag(FilterType.LesserThan))
                @operator += "<";
            if (filterType.HasFlag(FilterType.Equals))
                @operator += "=";

            return @operator;
        }

        private static string GenerateEquation<TValue>(Expression<Func<T, TValue>> selector,
            string desiredValue, FilterType filterType = FilterType.Equals)
        {
            var columnName = GetColumnID(selector);
            var @operator = GetOperator(filterType);

            if (typeof(TValue) != typeof(decimal) && typeof(TValue) != typeof(double)
                && typeof(TValue) != typeof(int) && typeof(TValue) != typeof(float)) desiredValue = $"'{desiredValue}'";

            return $"{columnName} {@operator} {desiredValue}";
        }

        public void RemoveAndFilterAt(int index) =>
            andEquations.RemoveAt(index);

        public void RemoveOrFilterAt(int index) =>
            orEquations.RemoveAt(index);

        public void Clear()
        {
            andEquations.Clear();
            orEquations.Clear();
            innerEquations.Clear();
        }

        private static PropertyInfo GetProperty<ObjectType, TValue>(Expression<Func<ObjectType, TValue>> selector)
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

        public FilterReply ToReply()
        {
            var reply = new FilterReply();
            reply.AndEquations.AddRange(andEquations);
            reply.OrEquations.AddRange(orEquations);
            reply.InnerEquations.AddRange(innerEquations);
            return reply;
        }

        private readonly List<string> andEquations;
        private readonly List<string> orEquations;
        private readonly List<string> innerEquations;
    }

    [Flags] public enum FilterType
    {
        Equals = 1,
        GreaterThan = 2,
        LesserThan = 4,
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
    }
}
