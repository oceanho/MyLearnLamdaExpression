using MyLearnLinq.LinqExpression.Internal;
using MyLearnLinq.LinqExpression.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MyLearnLinq.LinqExpression
{
    public class MyLearnQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            var elementType = TypeSystemUtil.GetElementType(expression.Type);
            return QueryProviderUtil.InternalCreateQueryByType(this, expression, elementType);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return QueryProviderUtil.InternalCreateQuery<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return MyLearnExpressionEngine.Execute(expression, false);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return MyLearnExpressionEngine.Execute<TResult>(expression);
        }
    }
}
