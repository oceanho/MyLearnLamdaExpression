using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyLearnLinq.LinqExpression.Internal
{
    internal class InnerMostWhereExpressionVisitor : ExpressionVisitor
    {
        private MethodCallExpression _innerWhereExpression;
        public MethodCallExpression GetInnerWhereExpression(Expression expression)
        {
            Visit(expression);
            return _innerWhereExpression;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name.Equals("where", StringComparison.OrdinalIgnoreCase))
                _innerWhereExpression = node;

            Visit(node.Arguments[0]);
            return node;
        }
    }
}
