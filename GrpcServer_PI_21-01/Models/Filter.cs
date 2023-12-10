using Microsoft.AspNetCore.Mvc.RazorPages;
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

            andEquations = new List<string>();
            orEquations = new List<string>();
            tableName = filterableModelAttribute.TableName;
        }

        public Filter(FilterReply reply) : this()
        {
            if (reply is not null)
            {
                if (!CheckCorrectFormat()) // проверка на попытки нежелаемых SQL инжектов
                    throw new Exception("Incorrect reply format recieved. Filter reply is corrupted");
                andEquations.AddRange(reply.AndEquations.Select(eq => tableName + "." + eq));
                orEquations.AddRange(reply.OrEquations.Select(eq => tableName + "." + eq));
                andEquations.AddRange(reply.AndInnerEquations.Select(eq =>
                {
                    var typeName = eq[..eq.IndexOf('.')];
                    var remainingEquation = eq[(eq.IndexOf('.') + 1)..];
                    var type= Type.GetType("GrpcServer_PI_21_01.Models."+typeName);
                    var filterableModelAttribute = type.GetCustomAttribute<FilterableModelAttribute>();
                    if (filterableModelAttribute is null)
                        throw new Exception(typeName + " model cannot be filtered.");

                    return filterableModelAttribute.TableName + "." + remainingEquation;
                }));
                orEquations.AddRange(reply.OrInnerEquations.Select(eq =>
                {
                    var typeName = eq[..eq.IndexOf('.')];
                    var remainingEquation = eq[(eq.IndexOf('.') + 1)..];
                    var type = Type.GetType("GrpcServer_PI_21_01.Models." + typeName);
                    var filterableModelAttribute = type.GetCustomAttribute<FilterableModelAttribute>();
                    if (filterableModelAttribute is null)
                        throw new Exception(typeName + " model cannot be filtered.");

                    return filterableModelAttribute.TableName + "." + remainingEquation;
                }));

            }
        }

        public IReadOnlyList<string> AndFilters => andEquations;
        public IReadOnlyList<string> OrFilters => orEquations;

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
            var equation = GenerateEquation(selector, desiredValue, tableName, filterType);
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
            var equation = GenerateEquation(selector, desiredValue, tableName, filterType);
            orEquations.Add(equation);
        }

        public void AddInnerJoinFilter<ObjectType, TValue>(Expression<Func<ObjectType, TValue>> selector,
            string desiredValue, FilterType filterType = FilterType.Equals)
        {
            var filterableModelAttribute = typeof(ObjectType).GetCustomAttribute<FilterableModelAttribute>();
            if (filterableModelAttribute is null)
                throw new Exception(typeof(ObjectType).Name + " model cannot be filtered.");
            var tableName = filterableModelAttribute.TableName;
            var equation = GenerateEquation(selector, desiredValue, tableName, filterType);
            andEquations.Add(equation);
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

        private static string GenerateEquation<ObjectType, TValue>(Expression<Func<ObjectType, TValue>> selector,
            string desiredValue, string tableName, FilterType filterType = FilterType.Equals)
        {
            var columnName = GetColumnID(selector);
            var @operator = GetOperator(filterType);

            if (typeof(TValue) != typeof(decimal) && typeof(TValue) != typeof(double)
                && typeof(TValue) != typeof(int) && typeof(TValue) != typeof(float)) desiredValue = $"'{desiredValue}'";

            return $"{tableName}.{columnName} {@operator} {desiredValue}";
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

        public void RemoveAndFilterAt(int index) =>
            andEquations.RemoveAt(index);

        public void RemoveOrFilterAt(int index) =>
            orEquations.RemoveAt(index);

        public string GenerateSQLAct(int page = -1)
        {
            var startQuery = $"SELECT DISTINCT act.id, dog_count, cat_count, organization_id, act.created_at, goal, municipal_contract_id FROM {tableName} " +
                $"left join act_catch_request on act.id = act_catch_request.act_id " +
                $"left join catch_request on catch_request.id = act_catch_request.catch_request_id";
            return GenerateSQL(page, startQuery);
        }
        //TODO
        //public string GenerateSQLContract(int page = -1)
        //{
        //    var startQuery = $"SELECT DISTINCT act.id, dog_count, cat_count, organization_id, act.created_at, goal, municipal_contract_id FROM {tableName} " +
        //        $"left join act_catch_request on act.id = act_catch_request.act_id " +
        //        $"left join catch_request on catch_request.id = act_catch_request.catch_request_id";
        //    return GenerateSQL(page, startQuery);
        //}

        public string GenerateSQLForCount()
        {
            var startQuery = $"SELECT count(*) FROM {tableName}";
            return GenerateSQL(-1, startQuery);
        }

        public string GenerateSQL(int page = -1)
        {
            var startQuery = $"SELECT * FROM {tableName}";
            return GenerateSQL(page, startQuery);
        }

        private string GenerateSQL(int page, string startQuery)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < andEquations.Count; i++)
            {
                var table = andEquations[i].Split('.', 2)[0];
                var expression = andEquations[i].Split('.', 2)[1];
                if (!dict.ContainsKey(table)) 
                    dict.Add(table, $"({table}.{expression}");
                else
                    dict[table] += $" and {table}.{expression}";
            }
            for (int i = 0; i < orEquations.Count; i++)
            {
                var table = orEquations[i].Split('.', 2)[0];
                var expression = orEquations[i].Split('.', 2)[1];
                if (andEquations.Count == 0 && !dict.ContainsKey(table))
                    dict.Add(table, $"({table}.{expression}");
                dict[table] += $" or {table}.{expression}";
            }
            if (andEquations.Count > 0 || orEquations.Count > 0)
            {
                startQuery += " WHERE ";
                foreach (var table in dict.Keys)
                    startQuery += dict[table] + ") and ";
                startQuery = startQuery.Remove(startQuery.Length - 5);
                //if (andEquations.Count > 0)
                //    startQuery += $"{string.Join(" and ", andEquations)}";
                //if (orEquations.Count > 0)
                //{
                //    if (andEquations.Count > 0)
                //        startQuery += " and ";
                //    startQuery += $"({string.Join(" or ", orEquations)})";
                //}
            }
            if (page != -1) startQuery += $" LIMIT 10 OFFSET {page * 10}";

            return startQuery + ";";
        }

        private bool CheckCorrectFormat()
        {
            static bool checkForCorrectFormat(string eq)
            {
                var items = eq.Split(' ');
                if (items.Length == 3)
                    return items[1].Length <= 2 && (items[1].Length == 1 || items[1][1] == '=');
                var possibleDate = string.Join(" ", items.Skip(2)).Replace("'", "");
                return DateTime.TryParse(possibleDate, out DateTime _);
            }
            return andEquations.All(checkForCorrectFormat) && orEquations.All(checkForCorrectFormat);
        }

        public void CombineWith(Filter<T> filter)
        {
            if (filter is null) return;
            andEquations.AddRange(filter.andEquations);
            orEquations.AddRange(filter.orEquations);
        }

        public void ExtendReply(FilterReply reply)
        {
            if (reply is not null)
            {
                reply.AndEquations.AddRange(andEquations);
                reply.OrEquations.AddRange(orEquations);
            }
        }

        private readonly List<string> andEquations;
        private readonly List<string> orEquations;
        private readonly string tableName;
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
        public FilterableModelAttribute(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; }
    }
}
