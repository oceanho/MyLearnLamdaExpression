using MyLearnLinq.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyLearnLinq.LinqExpression.Internal
{
    public class MyLearnExpressionTreeModifier : ExpressionVisitor
    {
        private IQueryable<Place> _queryablePlaces;

        internal MyLearnExpressionTreeModifier(IQueryable<Place> places)
        {
           _queryablePlaces = places;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            // Replace the constant QueryableTerraServerData arg with the queryable Place collection.
            if (c.Type == typeof(MyLearnQueryData<Place>))
                return Expression.Constant(this._queryablePlaces);
            else
                return c;
        }
    }
}
