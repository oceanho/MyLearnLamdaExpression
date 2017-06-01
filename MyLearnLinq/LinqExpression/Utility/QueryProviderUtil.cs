using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MyLearnLinq.LinqExpression.Utility
{
    internal static class QueryProviderUtil
    {
        private static readonly MethodInfo _internalCreateQueryMethod = typeof(QueryProviderUtil).GetMethod(nameof(InternalCreateQuery), BindingFlags.Static | BindingFlags.NonPublic);

        public static IQueryable<TElement> InternalCreateQuery<TElement>(MyLearnQueryProvider provider, Expression expression)
        {
            return new MyLearnQueryData<TElement>(provider, expression);
        }
        public static IQueryable InternalCreateQueryByType(MyLearnQueryProvider provider, Expression expression, Type elementType)
        {
            return (IQueryable)_internalCreateQueryMethod.MakeGenericMethod(elementType).Invoke(null, new object[] { provider, expression });
        }
    }
}
